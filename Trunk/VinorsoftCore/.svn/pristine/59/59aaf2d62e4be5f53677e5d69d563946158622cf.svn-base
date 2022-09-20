using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.ProfileService.Entities
{
    public class ProfileHealths : KTAppDomain
    {
        [ForeignKey("HealthStatus")]
        public Guid? HealthStatusId { set; get; }
        public CatHealthStatus HealthStatus { set; get; }

        [ForeignKey("BloodTypes")]
        public Guid? BloodTypeId { set; get; }
        public CatBloodTypes BloodTypes { set; get; }

        [ForeignKey("TattooStatus")]
        public Guid? TattooStatusId { set; get; }
        public CatTattooStatus TattooStatus { set; get; }

        [ForeignKey("PreferredHands")]
        public Guid? PreferredHandId { set; get; }
        public CatHands PreferredHands { set; get; }

        
        public double? LeftEyeSight { set; get; }
      
        public double? RightEyeSight { set; get; }

        public string LeftEyeSightWithGlass { set; get; }
   
        public string RightEyeSightWithGlass { set; get; }
        [MaxLength(1000)]
        public string MedicalHistory { set; get; }
        [MaxLength(1000)]
        public string ColorBlind { set; get; }
        [MaxLength(1000)]
        public string StrengthOfHand { set; get; }
        public int? Height { set; get; }
        public double? Weight { set; get; }

    }
}