using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Company.Technology.Model
{
    [Serializable]
    public class Task
    {
        public string Id { get; set; }

        public int TaskTypeId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int UrgencyId { get; set; }

        public int ImportanceId { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedAt { get; set; }

        public int StatusId { get; set; }
    }
}
