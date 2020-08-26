using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceTypeModel : IComparable<ConferenceTypeModel>
    {
        public string conferenceTypeName { get; set; }
        public int conferenceTypeId { get; set; }

        public int Compare(ConferenceTypeModel x, ConferenceTypeModel y)
        {
            if (string.Compare(x.conferenceTypeName, y.conferenceTypeName, StringComparison.OrdinalIgnoreCase) < 0)
            {
                return 1;
            }
            else if (string.Compare(x.conferenceTypeName, y.conferenceTypeName, StringComparison.OrdinalIgnoreCase) > 0)
            {
                return -1;
            }
            else
                return 0;
        }

        public int CompareTo(ConferenceTypeModel other)
        {
            if (string.Compare(this.conferenceTypeName, other.conferenceTypeName, StringComparison.OrdinalIgnoreCase) < 0)
            {
                return 1;
            }
            else if (string.Compare(this.conferenceTypeName, other.conferenceTypeName, StringComparison.OrdinalIgnoreCase) > 0)
            {
                return -1;
            }
            else
                return 0;
        }
    }
}
