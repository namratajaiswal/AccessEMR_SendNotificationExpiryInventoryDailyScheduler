using System;
using System.Collections.Generic;
using System.Text;

namespace SendNotificationExpiryInventoryDailyScheduler.Models
{
    public class NotifyClinicModel
    {
        public string ClinicName { get; set; }
        public string ClinicAdminName { get; set; }
        public string PlanName { get; set; }
        public int RemainingDays { get; set; }
        public string Email { get; set; }
    }
}
