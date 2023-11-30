using System;
using System.ComponentModel.DataAnnotations;

namespace Life_Liberator.Models
{
	public class Schedule
	{
        public int Id { get; set; }

        public DayOfWeek dayOfWeek { get; set; }

        public int TimeBlockId { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

    }
}

