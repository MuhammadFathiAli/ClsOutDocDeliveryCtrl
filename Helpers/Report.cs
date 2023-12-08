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
                        var retentions = _project.RetentionforDocumentsDelivery;
                        var deductions = _documents.Sum(d => d.Deduction);
                        var release = retentions - deductions;
                        var totalRequiredDocs = _documents.Count;
                        var totalDeliveredToOwner = _documents.Where(d => d.OwnerSubmitStatus == DeliveryStatus.DeliveredOnTime || d.OwnerSubmitStatus == DeliveryStatus.DeliveredLate).ToList().Count();
                        var totalDeliveredOntime = _documents.Where(d => d.OwnerSubmitStatus == DeliveryStatus.DeliveredOnTime).ToList().Count();
                        var totalDeliveredLate = _documents.Where(d => d.OwnerSubmitStatus == DeliveryStatus.DeliveredLate).ToList().Count();
                        var totalNotDelivered = _documents.Where(d => d.OwnerSubmitStatus == DeliveryStatus.Required || d.OwnerSubmitStatus == DeliveryStatus.NotSet || d.OwnerSubmitStatus == DeliveryStatus.Late).ToList().Count();
                        decimal performance = 0;
                        if (totalRequiredDocs != 0)
                        {
                            performance = Math.Round(((totalDeliveredOntime + ((decimal)totalDeliveredLate / 2)) / totalRequiredDocs) * 100, 2);
                        }
                        var totalContactorDelay = _documents.Sum(d => d.contractorDelay);
                        var totalConsultantDelay = _documents.Sum(d => d.consultantDelay);

                        #region ProjectInfo contributers Row
                        Documentt document = new Documentt(PageSize.A4.Rotate(), 1f, 1f, 100f, 100f);

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
                        PdfPCell startDateCell = new PdfPCell(new Phrase($"Current Date: {DateTime.Now.ToShortDateString()}",
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
                        itemHeaderCell.Colspan = 2; // Set horizontal alignment
                        pTable.AddCell(itemHeaderCell);

                        PdfPCell valueHeaderCell = new PdfPCell(new Phrase("Value",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                        valueHeaderCell.BackgroundColor = new BaseColor(Color.LightSkyBlue); // Set background color to light green
                        valueHeaderCell.Padding = 5; // Set padding
                        valueHeaderCell.MinimumHeight = 10f; // Set minimum height
                        valueHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueHeaderCell);

                        //PdfPCell commentHeaderCell = new PdfPCell(new Phrase("Comment",
                        //    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                        //commentHeaderCell.BackgroundColor = new BaseColor(Color.LightSkyBlue); // Set background color to light green
                        //commentHeaderCell.Padding = 5; // Set padding
                        //commentHeaderCell.MinimumHeight = 15f; // Set minimum height
                        //commentHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentHeaderCell);
                        #endregion

                        #region Total - Retention
                        PdfPCell itemTotalRetentionCell = new PdfPCell(new Phrase("Total documents retention",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemTotalRetentionCell.Padding = 5; // Set padding
                        itemTotalRetentionCell.MinimumHeight = 10f; // Set minimum height
                        itemTotalRetentionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemTotalRetentionCell.Colspan = 2;
                        pTable.AddCell(itemTotalRetentionCell);

                        PdfPCell valueTotalRetentionCell = new PdfPCell(new Phrase($"{retentions} %",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueTotalRetentionCell.Padding = 5; // Set padding
                        valueTotalRetentionCell.MinimumHeight = 10f; // Set minimum height
                        valueTotalRetentionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueTotalRetentionCell);

                        //PdfPCell commentTotalRetentionCell = new PdfPCell(new Phrase(""));
                        //commentTotalRetentionCell.Padding = 5; // Set padding
                        //commentTotalRetentionCell.MinimumHeight = 10f; // Set minimum height
                        //commentTotalRetentionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentTotalRetentionCell);
                        #endregion

                        #region Total - Deduction
                        PdfPCell itemTotalDeductionCell = new PdfPCell(new Phrase("Total documents deduction",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemTotalDeductionCell.Padding = 5; // Set padding
                        itemTotalDeductionCell.MinimumHeight = 10f; // Set minimum height
                        itemTotalDeductionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemTotalDeductionCell.Colspan = 2;
                        pTable.AddCell(itemTotalDeductionCell);

                        PdfPCell valueTotalDeductionCell = new PdfPCell(new Phrase($"{deductions} %",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueTotalDeductionCell.Padding = 5; // Set padding
                        valueTotalDeductionCell.MinimumHeight = 10f; // Set minimum height
                        valueTotalDeductionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueTotalDeductionCell);

                        //PdfPCell commentTotalDeductionCell = new PdfPCell(new Phrase(""));
                        //commentTotalDeductionCell.Padding = 5; // Set padding
                        //commentTotalDeductionCell.MinimumHeight = 10f; // Set minimum height
                        //commentTotalDeductionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentTotalDeductionCell);
                        #endregion

                        #region Release
                        PdfPCell itemReleaseCell = new PdfPCell(new Phrase("Release", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemReleaseCell.Padding = 5; // Set padding
                        itemReleaseCell.MinimumHeight = 10f; // Set minimum height
                        itemReleaseCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemReleaseCell.Colspan = 2;
                        pTable.AddCell(itemReleaseCell);

                        PdfPCell valueReleaseCell = new PdfPCell(new Phrase($"{release} %",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueReleaseCell.Padding = 5; // Set padding
                        valueReleaseCell.MinimumHeight = 10f; // Set minimum height
                        valueReleaseCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueReleaseCell);

                        //PdfPCell commentReleaseCell = new PdfPCell(new Phrase(""));
                        //commentReleaseCell.Padding = 5; // Set padding
                        //commentReleaseCell.MinimumHeight = 10f; // Set minimum height
                        //commentReleaseCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentReleaseCell);
                        #endregion

                        #region Total Required Docs No
                        PdfPCell itemReqDocsCell = new PdfPCell(new Phrase("Number of total documents required", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemReqDocsCell.Padding = 5; // Set padding
                        itemReqDocsCell.MinimumHeight = 10f; // Set minimum height
                        itemReqDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemReqDocsCell.Colspan = 2;
                        pTable.AddCell(itemReqDocsCell);

                        PdfPCell valueReqDocsCell = new PdfPCell(new Phrase($"{totalRequiredDocs}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueReqDocsCell.Padding = 5; // Set padding
                        valueReqDocsCell.MinimumHeight = 10f; // Set minimum height
                        valueReqDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueReqDocsCell);

                        //PdfPCell commentReqDocsCell = new PdfPCell(new Phrase(""));
                        //commentReqDocsCell.Padding = 5; // Set padding
                        //commentReqDocsCell.MinimumHeight = 10f; // Set minimum height
                        //commentReqDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentReqDocsCell);
                        #endregion

                        #region Total Deliverd to owner No 
                        PdfPCell itemDeliveredDocsCell = new PdfPCell(new Phrase("Number of documents delivered to owner",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemDeliveredDocsCell.Padding = 5; // Set padding
                        itemDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        itemDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemDeliveredDocsCell.Colspan = 2;
                        pTable.AddCell(itemDeliveredDocsCell);

                        PdfPCell valueDeliveredDocsCell = new PdfPCell(new Phrase($"{totalDeliveredToOwner}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueDeliveredDocsCell.Padding = 5; // Set padding
                        valueDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        valueDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueDeliveredDocsCell);

                        //PdfPCell commentDeliveredDocsCell = new PdfPCell(new Phrase(""));
                        //commentDeliveredDocsCell.Padding = 5; // Set padding
                        //commentDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        //commentDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentDeliveredDocsCell);
                        #endregion

                        #region Total Delivered Late
                        PdfPCell itemLateDocsCell = new PdfPCell(new Phrase("Number of documents delivered late",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemLateDocsCell.Padding = 5; // Set padding
                        itemLateDocsCell.MinimumHeight = 10f; // Set minimum height
                        itemLateDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemLateDocsCell.Colspan = 2;
                        pTable.AddCell(itemLateDocsCell);

                        PdfPCell valueLateDocsCell = new PdfPCell(new Phrase($"{totalDeliveredLate}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueLateDocsCell.Padding = 5; // Set padding
                        valueLateDocsCell.MinimumHeight = 10f; // Set minimum height
                        valueLateDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueLateDocsCell);

                        //PdfPCell commentLateDocsCell = new PdfPCell(new Phrase(""));
                        //commentLateDocsCell.Padding = 5; // Set padding
                        //commentLateDocsCell.MinimumHeight = 10f; // Set minimum height
                        //commentLateDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentLateDocsCell);
                        #endregion

                        #region Total Not Delivered
                        PdfPCell itemNotDeliveredDocsCell = new PdfPCell(new Phrase("Number of documents not delivered",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemNotDeliveredDocsCell.Padding = 5; // Set padding
                        itemNotDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        itemNotDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemNotDeliveredDocsCell.Colspan= 2;
                        pTable.AddCell(itemNotDeliveredDocsCell);

                        PdfPCell valueNotDeliveredDocsCell = new PdfPCell(new Phrase($"{totalNotDelivered}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueNotDeliveredDocsCell.Padding = 5; // Set padding
                        valueNotDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        valueNotDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueNotDeliveredDocsCell);

                        //PdfPCell commentNotDeliveredDocsCell = new PdfPCell(new Phrase(""));
                        //commentNotDeliveredDocsCell.Padding = 5; // Set padding
                        //commentNotDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                        //commentNotDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentNotDeliveredDocsCell);
                        #endregion

                        #region Contractor Delay
                        PdfPCell itemContctorDelayCell = new PdfPCell(new Phrase("Contractor's total delay (Days)",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemContctorDelayCell.Padding = 5; // Set padding
                        itemContctorDelayCell.MinimumHeight = 10f; // Set minimum height
                        itemContctorDelayCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemContctorDelayCell.Colspan = 2;
                        pTable.AddCell(itemContctorDelayCell);

                        PdfPCell valueContctorDelayCell = new PdfPCell(new Phrase($"{totalContactorDelay}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueContctorDelayCell.Padding = 5; // Set padding
                        valueContctorDelayCell.MinimumHeight = 10f; // Set minimum height
                        valueContctorDelayCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueContctorDelayCell);

                        //PdfPCell commentContctorDelayCell = new PdfPCell(new Phrase(""));
                        //commentContctorDelayCell.Padding = 5; // Set padding
                        //commentContctorDelayCell.MinimumHeight = 10f; // Set minimum height
                        //commentContctorDelayCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentContctorDelayCell);
                        #endregion

                        #region Consultant Delay
                        PdfPCell itemConsultantDelayCell = new PdfPCell(new Phrase("Consultant's total delay (Days)",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemConsultantDelayCell.Padding = 5; // Set padding
                        itemConsultantDelayCell.MinimumHeight = 10f; // Set minimum height
                        itemConsultantDelayCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemConsultantDelayCell.Colspan= 2; 
                        pTable.AddCell(itemConsultantDelayCell);

                        PdfPCell valueConsultantDelayCell = new PdfPCell(new Phrase($"{totalConsultantDelay}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueConsultantDelayCell.Padding = 5; // Set padding
                        valueConsultantDelayCell.MinimumHeight = 10f; // Set minimum height
                        valueConsultantDelayCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueConsultantDelayCell);

                        //PdfPCell commentConsultantDelayCell = new PdfPCell(new Phrase(""));
                        //commentConsultantDelayCell.Padding = 5; // Set padding
                        //commentConsultantDelayCell.MinimumHeight = 10f; // Set minimum height
                        //commentConsultantDelayCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentConsultantDelayCell);
                        #endregion

                        #region Project Total Duration
                        PdfPCell itemtotalDurationCell = new PdfPCell(new Phrase("Project Total Duration (Days)",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemtotalDurationCell.Padding = 5; // Set padding
                        itemtotalDurationCell.MinimumHeight = 10f; // Set minimum height
                        itemtotalDurationCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemtotalDurationCell.Colspan = 2;
                        pTable.AddCell(itemtotalDurationCell);

                        PdfPCell valuetotalDurationCell = new PdfPCell(new Phrase($"{(_project.PlannedEndDate - _project.StartDate).Days}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valuetotalDurationCell.Padding = 5; // Set padding
                        valuetotalDurationCell.MinimumHeight = 10f; // Set minimum height
                        valuetotalDurationCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valuetotalDurationCell);

                        //PdfPCell commenttotalDurationCell = new PdfPCell(new Phrase(""));
                        //commenttotalDurationCell.Padding = 5; // Set padding
                        //commenttotalDurationCell.MinimumHeight = 10f; // Set minimum height
                        //commenttotalDurationCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commenttotalDurationCell);
                        #endregion


                        #region Contract Price
                        PdfPCell itemContractPriceCell = new PdfPCell(new Phrase("Contract Price (currency)",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemContractPriceCell.Padding = 5; // Set padding
                        itemContractPriceCell.MinimumHeight = 10f; // Set minimum height
                        itemContractPriceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemContractPriceCell.Colspan= 2;
                        pTable.AddCell(itemContractPriceCell);

                        PdfPCell valueContractPriceCell = new PdfPCell(new Phrase($"{_project.ContractValue}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueContractPriceCell.Padding = 5; // Set padding
                        valueContractPriceCell.MinimumHeight = 10f; // Set minimum height
                        valueContractPriceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueContractPriceCell);

                        //PdfPCell commentContractPriceCell = new PdfPCell(new Phrase(""));
                        //commentContractPriceCell.Padding = 5; // Set padding
                        //commentContractPriceCell.MinimumHeight = 10f; // Set minimum height
                        //commentContractPriceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentContractPriceCell);
                        #endregion

                        #region Total Deduction Value
                        PdfPCell itemDeductionValueCell = new PdfPCell(new Phrase("Total Deduction value (Currency)",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemDeductionValueCell.Padding = 5; // Set padding
                        itemDeductionValueCell.MinimumHeight = 10f; // Set minimum height
                        itemDeductionValueCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemDeductionValueCell.Colspan = 2;
                        pTable.AddCell(itemDeductionValueCell);

                        PdfPCell valueDeductionValueCell = new PdfPCell(new Phrase($"{Math.Round((_project.ContractValue * deductions * (decimal)0.01)??decimal.Zero,2)}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valueDeductionValueCell.Padding = 5; // Set padding
                        valueDeductionValueCell.MinimumHeight = 10f; // Set minimum height
                        valueDeductionValueCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valueDeductionValueCell);

                        //PdfPCell commentDeductionValueCell = new PdfPCell(new Phrase(""));
                        //commentDeductionValueCell.Padding = 5; // Set padding
                        //commentDeductionValueCell.MinimumHeight = 10f; // Set minimum height
                        //commentDeductionValueCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentDeductionValueCell);
                        #endregion

                        #region Performance

                        PdfPCell itemPerformanceCell = new PdfPCell(new Phrase("Contractor performance (according to time commitment)",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        itemPerformanceCell.Padding = 5; // Set padding
                        itemPerformanceCell.MinimumHeight = 10f; // Set minimum height
                        itemPerformanceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        itemPerformanceCell.Colspan=2;
                        pTable.AddCell(itemPerformanceCell);

                        PdfPCell valuePerformanceCell = new PdfPCell(new Phrase($"{performance} %",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        valuePerformanceCell.Padding = 5; // Set padding
                        valuePerformanceCell.MinimumHeight = 10f; // Set minimum height
                        valuePerformanceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        pTable.AddCell(valuePerformanceCell);

                        //PdfPCell commentPerformanceCell = new PdfPCell(new Phrase("The reason behind that is the late response of the consultant",
                        //    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                        //commentPerformanceCell.Padding = 5; // Set padding
                        //commentPerformanceCell.MinimumHeight = 10f; // Set minimum height
                        //commentPerformanceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                        //pTable.AddCell(commentPerformanceCell);
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
