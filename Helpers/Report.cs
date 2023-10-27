using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = ClsOutDocDeliveryCtrl.Entities.Document;
using Documentt = iTextSharp.text.Document;

namespace ClsOutDocDeliveryCtrl.Helpers
{
    public class Report
    {
        private Project _project;
        private List<Document> _documents;
        public Report(int projectID)
        {
            getProject(projectID);
            if (_project is not null)
            {
                getDocuments(projectID);
            }
        }

        private void getDocuments(int projectID)
        {
            using (var context = new AppDBContext())
            {
                _documents = context.Documents.Where(d => d.ProjectId == projectID).ToList();
            }
        }

        private void getProject(int projectID)
        {
            using (var context = new AppDBContext())
            {
                _project = context.Projects.FirstOrDefault(p => p.ProjectId == projectID);
            }
        }

        public void GenerateReport()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF (*.pdf)|*.pdf";
            save.FileName = "Result.pdf";
            bool ErrorMessage = false;
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(save.FileName))
                {
                    try
                    {
                        File.Delete(save.FileName);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = true;
                        MessageBox.Show("Unable to write data to disk: " + ex.Message);
                    }
                }
                if (!ErrorMessage)
                {
                    try
                    {
                        var retentions = _documents.Sum(d => d.Retention);
                        var deductions = _documents.Sum(d => d.Deduction);
                        var release = retentions - deductions;
                        var totalRequiredDocs = _documents.Count;
                        var totalDeliveredToOwner = _documents.Where(d => d.OwnerSubmitStatus == DeliveryStatus.DeliveredOnTime || d.OwnerSubmitStatus == DeliveryStatus.DeliveredLate).ToList().Count();
                        var totalDeliveredOntime = _documents.Where(d => d.OwnerSubmitStatus == DeliveryStatus.DeliveredOnTime).ToList().Count();
                        var totalDeliveredLate = _documents.Where(d => d.OwnerSubmitStatus == DeliveryStatus.DeliveredLate).ToList().Count();
                        var totalNotDelivered = _documents.Where(d => d.OwnerSubmitStatus == DeliveryStatus.Pending || d.OwnerSubmitStatus == DeliveryStatus.NotSet || d.OwnerSubmitStatus == DeliveryStatus.Late).ToList().Count();
                        decimal performance = 0;
                        if (totalDeliveredToOwner != 0)
                        {
                            performance = ((totalDeliveredOntime + ((decimal)totalDeliveredLate / 2)) / totalDeliveredToOwner) * 100;
                        }

                        #region ProjectInfo contributers Row
                        Documentt document = new Documentt(PageSize.A4.Rotate(), 1f, 1f, 150f, 150f);

                        PdfWriter.GetInstance(document, new FileStream(save.FileName, FileMode.Create));
                        document.Open();
                        PdfPTable pTable = new PdfPTable(3);
                        PdfPCell ownerCell = new PdfPCell(new Phrase($"project Owner: {_project.Name}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                        ownerCell.BackgroundColor = new BaseColor(Color.LightGreen);  // Set background color
                        ownerCell.Padding = 5; // Set padding
                        ownerCell.MinimumHeight = 25f; // Set minimum height
                        ownerCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(ownerCell);

                        PdfPCell consultCell = new PdfPCell(new Phrase($"project Consultant: {_project.ConsultantName}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                        consultCell.BackgroundColor = new BaseColor(Color.LightGreen); // Set background color to light green
                        consultCell.Padding = 5; // Set padding
                        consultCell.MinimumHeight = 25f; // Set minimum height
                        consultCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(consultCell);

                        PdfPCell contractorCell = new PdfPCell(new Phrase($"project Contractor: {_project.ContractorName}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                        contractorCell.BackgroundColor = new BaseColor(Color.LightGreen); // Set background color to light green
                        contractorCell.Padding = 5; // Set padding
                        contractorCell.MinimumHeight = 25f; // Set minimum height
                        contractorCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(contractorCell);
                        #endregion

                        #region ProjectInfo Dates Row
                        PdfPCell startDateCell = new PdfPCell(new Phrase($"Starting Date: {_project.StartDate.ToShortDateString()}",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        startDateCell.Padding = 5; // Set padding
                        startDateCell.MinimumHeight = 10f; // Set minimum height
                        startDateCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(startDateCell);


                        PdfPCell projectNameCell = new PdfPCell(new Phrase($"project Name: {_project.Name}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        projectNameCell.Padding = 5; // Set padding
                        projectNameCell.MinimumHeight = 10f; // Set minimum height
                        projectNameCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(projectNameCell);


                        PdfPCell endDateCell = new PdfPCell(new Phrase($"Planned End Date: {_project.PlannedEndDate.ToShortDateString()}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        endDateCell.Padding = 5; // Set padding
                        endDateCell.MinimumHeight = 10f; // Set minimum height
                        endDateCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(endDateCell);
                        #endregion

                        #region 2 Headers Rows 
                        PdfPCell mainHeaderCell = new PdfPCell(new Phrase("Contractor's Documentation Performance",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                        mainHeaderCell.BackgroundColor = new BaseColor(Color.LightSkyBlue); // Set background color to light green
                        mainHeaderCell.Padding = 5; // Set padding
                        mainHeaderCell.MinimumHeight = 15f; // Set minimum height
                        mainHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        mainHeaderCell.Colspan = 3; // Set horizontal alignment
                        pTable.AddCell(mainHeaderCell);


                        PdfPCell itemHeaderCell = new PdfPCell(new Phrase("Item",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                        itemHeaderCell.BackgroundColor = new BaseColor(Color.LightSkyBlue); // Set background color to light green
                        itemHeaderCell.Padding = 5; // Set padding
                        itemHeaderCell.MinimumHeight = 10f; // Set minimum height
                        itemHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(itemHeaderCell);

                        PdfPCell valueHeaderCell = new PdfPCell(new Phrase("Value",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                        valueHeaderCell.BackgroundColor = new BaseColor(Color.LightSkyBlue); // Set background color to light green
                        valueHeaderCell.Padding = 5; // Set padding
                        valueHeaderCell.MinimumHeight = 10f; // Set minimum height
                        valueHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueHeaderCell);

                        PdfPCell commentHeaderCell = new PdfPCell(new Phrase("Comment",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                        commentHeaderCell.BackgroundColor = new BaseColor(Color.LightSkyBlue); // Set background color to light green
                        commentHeaderCell.Padding = 5; // Set padding
                        commentHeaderCell.MinimumHeight = 15f; // Set minimum height
                        commentHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(commentHeaderCell);
                        #endregion

                        #region Total - Retention
                        PdfPCell itemTotalRetentionCell = new PdfPCell(new Phrase("Total documents retention",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemTotalRetentionCell.Padding = 5; // Set padding
                        itemTotalRetentionCell.MinimumHeight = 10f; // Set minimum height
                        itemTotalRetentionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(itemTotalRetentionCell);

                        PdfPCell valueTotalRetentionCell = new PdfPCell(new Phrase($"{retentions} %",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueTotalRetentionCell.Padding = 5; // Set padding
                        valueTotalRetentionCell.MinimumHeight = 10f; // Set minimum height
                        valueTotalRetentionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueTotalRetentionCell);

                        PdfPCell commentTotalRetentionCell = new PdfPCell(new Phrase(""));
                        commentTotalRetentionCell.Padding = 5; // Set padding
                        commentTotalRetentionCell.MinimumHeight = 10f; // Set minimum height
                        commentTotalRetentionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(commentTotalRetentionCell);
                        #endregion

                        #region Total - Deduction
                        PdfPCell itemTotalDeductionCell = new PdfPCell(new Phrase("Total documents deduction",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemTotalDeductionCell.Padding = 5; // Set padding
                        itemTotalDeductionCell.MinimumHeight = 10f; // Set minimum height
                        itemTotalDeductionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(itemTotalDeductionCell);

                        PdfPCell valueTotalDeductionCell = new PdfPCell(new Phrase($"{deductions} %",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueTotalDeductionCell.Padding = 5; // Set padding
                        valueTotalDeductionCell.MinimumHeight = 10f; // Set minimum height
                        valueTotalDeductionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueTotalDeductionCell);

                        PdfPCell commentTotalDeductionCell = new PdfPCell(new Phrase(""));
                        commentTotalDeductionCell.Padding = 5; // Set padding
                        commentTotalDeductionCell.MinimumHeight = 10f; // Set minimum height
                        commentTotalDeductionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(commentTotalDeductionCell);
                        #endregion

                        #region Release
                        PdfPCell itemReleaseCell = new PdfPCell(new Phrase("Release", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemReleaseCell.Padding = 5; // Set padding
                        itemReleaseCell.MinimumHeight = 10f; // Set minimum height
                        itemReleaseCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(itemReleaseCell);

                        PdfPCell valueReleaseCell = new PdfPCell(new Phrase($"{release} %",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueReleaseCell.Padding = 5; // Set padding
                        valueReleaseCell.MinimumHeight = 10f; // Set minimum height
                        valueReleaseCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueReleaseCell);

                        PdfPCell commentReleaseCell = new PdfPCell(new Phrase(""));
                        commentReleaseCell.Padding = 5; // Set padding
                        commentReleaseCell.MinimumHeight = 10f; // Set minimum height
                        commentReleaseCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(commentReleaseCell);
                        #endregion

                        #region Total Required Docs No
                        PdfPCell itemReqDocsCell = new PdfPCell(new Phrase("Number of total documents required", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemReqDocsCell.Padding = 5; // Set padding
                        itemReqDocsCell.MinimumHeight = 10f; // Set minimum height
                        itemReqDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(itemReqDocsCell);

                        PdfPCell valueReqDocsCell = new PdfPCell(new Phrase($"{totalRequiredDocs}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueReqDocsCell.Padding = 5; // Set padding
                        valueReqDocsCell.MinimumHeight = 10f; // Set minimum height
                        valueReqDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueReqDocsCell);

                        PdfPCell commentReqDocsCell = new PdfPCell(new Phrase(""));
                        commentReqDocsCell.Padding = 5; // Set padding
                        commentReqDocsCell.MinimumHeight = 10f; // Set minimum height
                        commentReqDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(commentReqDocsCell);
                        #endregion

                        #region Total Deliverd to owner No 
                        PdfPCell itemDeliveredDocsCell = new PdfPCell(new Phrase("Number of documents delivered to owner",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemDeliveredDocsCell.Padding = 5; // Set padding
                        itemDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        itemDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(itemDeliveredDocsCell);

                        PdfPCell valueDeliveredDocsCell = new PdfPCell(new Phrase($"{totalDeliveredToOwner}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueDeliveredDocsCell.Padding = 5; // Set padding
                        valueDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        valueDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueDeliveredDocsCell);

                        PdfPCell commentDeliveredDocsCell = new PdfPCell(new Phrase(""));
                        commentDeliveredDocsCell.Padding = 5; // Set padding
                        commentDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        commentDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(commentDeliveredDocsCell);
                        #endregion

                        #region Total Delivered Late
                        PdfPCell itemLateDocsCell = new PdfPCell(new Phrase("Number of documents delivered late",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemLateDocsCell.Padding = 5; // Set padding
                        itemLateDocsCell.MinimumHeight = 10f; // Set minimum height
                        itemLateDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(itemLateDocsCell);

                        PdfPCell valueLateDocsCell = new PdfPCell(new Phrase($"{totalDeliveredLate}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueLateDocsCell.Padding = 5; // Set padding
                        valueLateDocsCell.MinimumHeight = 10f; // Set minimum height
                        valueLateDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueLateDocsCell);

                        PdfPCell commentLateDocsCell = new PdfPCell(new Phrase(""));
                        commentLateDocsCell.Padding = 5; // Set padding
                        commentLateDocsCell.MinimumHeight = 10f; // Set minimum height
                        commentLateDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(commentLateDocsCell);
                        #endregion

                        #region Total Not Delivered
                        PdfPCell itemNotDeliveredDocsCell = new PdfPCell(new Phrase("Number of documents not delivered",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemNotDeliveredDocsCell.Padding = 5; // Set padding
                        itemNotDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        itemNotDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(itemNotDeliveredDocsCell);

                        PdfPCell valueNotDeliveredDocsCell = new PdfPCell(new Phrase($"{totalNotDelivered}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueNotDeliveredDocsCell.Padding = 5; // Set padding
                        valueNotDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        valueNotDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueNotDeliveredDocsCell);

                        PdfPCell commentNotDeliveredDocsCell = new PdfPCell(new Phrase(""));
                        commentNotDeliveredDocsCell.Padding = 5; // Set padding
                        commentNotDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        commentNotDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(commentNotDeliveredDocsCell);
                        #endregion

                        #region Performance

                        PdfPCell itemPerformanceCell = new PdfPCell(new Phrase("Contractor performance (according to time commitment)",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemPerformanceCell.Padding = 5; // Set padding
                        itemPerformanceCell.MinimumHeight = 10f; // Set minimum height
                        itemPerformanceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(itemPerformanceCell);

                        PdfPCell valuePerformanceCell = new PdfPCell(new Phrase($"{performance} %",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valuePerformanceCell.Padding = 5; // Set padding
                        valuePerformanceCell.MinimumHeight = 10f; // Set minimum height
                        valuePerformanceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valuePerformanceCell);

                        PdfPCell commentPerformanceCell = new PdfPCell(new Phrase("The reason behind that is the late response of the consultant",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        commentPerformanceCell.Padding = 5; // Set padding
                        commentPerformanceCell.MinimumHeight = 10f; // Set minimum height
                        commentPerformanceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(commentPerformanceCell);
                        #endregion

                        document.Add(pTable);
                        document.Close();
                        MessageBox.Show("Data Exported Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
