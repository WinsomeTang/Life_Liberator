//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//namespace Life_Liberator.Models
//{
//    public class Schedule
//    {
//        [Key]
//        public int ScheduleId { get; set; }

//        [ForeignKey("User")]

//        public int UserId { get; set; }

//        [NotMapped]
//        public List<TimeBlock> Monday { get; set; }

//        [NotMapped]
//        public List<TimeBlock> Tuesday { get; set; }

//        [NotMapped]
//        public List<TimeBlock> Wednesday { get; set; }

//        [NotMapped]
//        public List<TimeBlock> Thursday { get; set; }

//        [NotMapped]
//        public List<TimeBlock> Friday { get; set; }

//        [NotMapped]
//        public List<TimeBlock> Saturday { get; set; }

//        [NotMapped]
//        public List<TimeBlock> Sunday { get; set; }

//        // Property to store JSON representation of the lists in the database
//        //[JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
//        public string TimeBlocksJson
//        {
//            get
//            {
//                return JsonConvert.SerializeObject(new
//                {
//                    Monday,
//                    Tuesday,
//                    Wednesday,
//                    Thursday,
//                    Friday,
//                    Saturday,
//                    Sunday
//                }, Formatting.None,
//                new JsonSerializerSettings
//                {
//                    NullValueHandling = NullValueHandling.Ignore
//                });
//            }
//            set
//            {
//                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(value);

//                Monday = DeserializeTimeBlocks(data.GetValueOrDefault("Monday"));
//                Tuesday = DeserializeTimeBlocks(data.GetValueOrDefault("Tuesday"));
//                Wednesday = DeserializeTimeBlocks(data.GetValueOrDefault("Wednesday"));
//                Thursday = DeserializeTimeBlocks(data.GetValueOrDefault("Thursday"));
//                Friday = DeserializeTimeBlocks(data.GetValueOrDefault("Friday"));
//                Saturday = DeserializeTimeBlocks(data.GetValueOrDefault("Saturday"));
//                Sunday = DeserializeTimeBlocks(data.GetValueOrDefault("Sunday"));
//            }
//        }

//        private List<TimeBlock> DeserializeTimeBlocks(object value)
//        {
//            if (value is null)
//            {
//                return new List<TimeBlock>();
//            }

//            if (value is JArray timeBlocksArray)
//            {
//                return timeBlocksArray.ToObject<List<TimeBlock>>();
//            }

//            // Handle the case when only one TimeBlock is provided
//            return new List<TimeBlock> { ((JObject)value).ToObject<TimeBlock>() };
//        }
//    }
//}