using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ConferenceComparer : IComparer<ConferenceAttendanceModel>
    {
        public int Compare([AllowNull] ConferenceAttendanceModel x, [AllowNull] ConferenceAttendanceModel y)
        {
            /*if (x.DictionaryParticipantStatusId == 3 && (y.DictionaryParticipantStatusId == 1 || y.DictionaryParticipantStatusId == 2)
            {
                return -1;
            }

            if (x.DictionaryParticipantStatusId == 3 && y.DictionaryParticipantStatusId == 3)
            {
                return 0;
            }

            if (x.DictionaryParticipantStatusId == 2 && y.DictionaryParticipantStatusId == 3)
            {
                return 1;
            }

            if (x.DictionaryParticipantStatusId == 2 && y.DictionaryParticipantStatusId == 2)
            {
                return 0;
            }*/
            if (x.DictionaryParticipantStatusId == y.DictionaryParticipantStatusId && x.DictionaryParticipantStatusId != 0 && y.DictionaryParticipantStatusId != 0)
                return 0;
            

            if (x.DictionaryParticipantStatusId == 3)
                return -1;
           

            if (x.DictionaryParticipantStatusId == 2)
                return 1;
            

            if (x.DictionaryParticipantStatusId == 1 && y.DictionaryParticipantStatusId == 2)
                return -1;
            

            if (y.DictionaryParticipantStatusId == 3)
                return 1;

            if (x.DictionaryParticipantStatusId == 0 && y.DictionaryParticipantStatusId != 0)
                return -1;
            

            if (y.DictionaryParticipantStatusId == 0 && x.DictionaryParticipantStatusId != 0)
                return 1;

            else
                return 0;
            
        }
    }
}
