using System;
using System.Collections.Generic;
using System.Text;

namespace Atwork.Models
{
    public class Activity
    {
        public string UniqueID { get; set; }
        public string Title { get; set; }
        public string coUniqueID { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public string TimeCommitment { get; set; }
        public string TimeCommitmentDecimal { get; set; }
        public string DatesConfirmed { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string CategoryName { get; set; }
        public string SubCategory { get; set; }
        public string SubCategoryName { get; set; }
        public string Status { get; set; }
        public string Partner { get; set; }
        public string PartnerEmail { get; set; }
        public string ActivityLanguage { get; set; }
        public string ActivityLanguageID { get; set; }
        public string Audience { get; set; }
        public string SpecialRequirements { get; set; }
        public string CostCoveredEmployee { get; set; }
        public string CostCoveredCompany { get; set; }
        public string AddActivity_HoursCommitted { get; set; }
        public string AddActivity_StartTime { get; set; }
        public string AddActivity_EndTime { get; set; }
        public string AddActivity_ParticipantsMinNumber { get; set; }
        public string AddActivity_ParticipantsMaxNumber { get; set; }
        public string AddActivity_OrgName { get; set; }
        public string AddActivity_Website { get; set; }
        public string AddActivity_AdditionalInfo { get; set; }
        public string AddActivity_CoordinatorEmail { get; set; }
        public string BackgroundImage { get; set; }
    }
}
