using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notifications.Models
{
    public class Notifications
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public  DateTime CreatedDate { get; set; }

    }
}