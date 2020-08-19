using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atwork.DTO
{
    public class ActivityDTO
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("prouniqueid")]
        public string proUniqueID { get; set; }

        [JsonProperty("protitle")]
        public string proTitle { get; set; }

        [JsonProperty("couniqueid")]
        public string coUniqueID { get; set; }

        [JsonProperty("procompany")]
        public string proCompany { get; set; }

        [JsonProperty("prodescription")]
        public string proDescription { get; set; }

        [JsonProperty("prolocation")]
        public string proLocation { get; set; }

        [JsonProperty("proaddress1")]
        public string proAddress1 { get; set; }

        [JsonProperty("proaddress2")]
        public string proAddress2 { get; set; }

        [JsonProperty("propostalcode")]
        public string proPostalCode { get; set; }

        [JsonProperty("procity")]
        public string proCity { get; set; }

        [JsonProperty("procountry")]
        public string proCountry { get; set; }

        [JsonProperty("procontinent")]
        public string proContinent { get; set; }

        [JsonProperty("protimecommitment")]
        public string proTimeCommitment { get; set; }

        [JsonProperty("proTimeCommitmentDecimal")]
        public string proTimeCommitmentDecimal { get; set; }

        [JsonProperty("proDatesConfirmed")]
        public string proDatesConfirmed { get; set; }

        [JsonProperty("proType")]
        public string proType { get; set; }

        [JsonProperty("proCategory")]
        public string proCategory { get; set; }

        [JsonProperty("proCategoryName")]
        public string proCategoryName { get; set; }

        [JsonProperty("proSubCategory")]
        public string proSubCategory { get; set; }

        [JsonProperty("proSubCategoryName")]
        public string proSubCategoryName { get; set; }

        [JsonProperty("proStatus")]
        public string proStatus { get; set; }

        [JsonProperty("proPartner")]
        public string proPartner { get; set; }

        [JsonProperty("proPartnerEmail")]
        public string proPartnerEmail { get; set; }

        [JsonProperty("proActivityLanguage")]
        public string proActivityLanguage { get; set; }

        [JsonProperty("proActivityLanguageId")]
        public string proActivityLanguageID { get; set; }

        [JsonProperty("proAudience")]
        public string proAudience { get; set; }

        [JsonProperty("proSpecialRequirements")]
        public string proSpecialRequirements { get; set; }

        [JsonProperty("proCostCoveredEmployee")]
        public string proCostCoveredEmployee { get; set; }

        [JsonProperty("proCostCoveredCompany")]
        public string proCostCoveredCompany { get; set; }

        [JsonProperty("proAddActivity_HoursCommitted")]
        public string proAddActivity_HoursCommitted { get; set; }

        [JsonProperty("proAddActivity_StartTime")]
        public string proAddActivity_StartTime { get; set; }

        [JsonProperty("proAddActivity_EndTIme")]
        public string proAddActivity_EndTime { get; set; }

        [JsonProperty("proAddActivity_ParticipantsMinNumber")]
        public string proAddActivity_ParticipantsMinNumber { get; set; }

        [JsonProperty("proAddActivity_ParticipantsMaxNumber")]
        public string proAddActivity_ParticipantsMaxNumber { get; set; }

        [JsonProperty("proAddActivity_OrgName")]
        public string proAddActivity_OrgName { get; set; }

        [JsonProperty("proAddActivity_Website")]
        public string proAddActivity_Website { get; set; }

        [JsonProperty("proAddActivity_AdditionalInfo")]
        public string proAddActivity_AdditionalInfo { get; set; }

        [JsonProperty("proAddActivity_CoordinatorEmail")]
        public string proAddActivity_CoordinatorEmail { get; set; }

        [JsonProperty("proPublishedDate")]
        public string proPublishedDate { get; set; }

        [JsonProperty("proAddActivityDate")]
        public string proAddActivityDate { get; set; }

        [JsonProperty("proBackgroundImage")]
        public string proBackgroundImage { get; set; }

        [JsonProperty("proDeliveredMethod")]
        public string proDeliveryMethod { get; set; }
    }
}
