using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayloadSigning.Test {

    [DataContract]
    public class Session {

        [DataMember(Name = "p")]
        public Person Person { get; set; }

        [DataMember(Name = "r")]
        public IList<uint> ProductIds { get; set; } // List of AMember products

        [DataMember(Name = "e")]
        public DateTime ExpiresAt { get; set; } // utc time
    }

    [DataContract]
    public class Person {

        [DataMember(Name = "q")]
        public uint Id { get; set; } // aMember user id

        [DataMember(Name = "np")]
        public string PreferredName { get; set; }

        [DataMember(Name = "e")]
        public string EmailAddress { get; set; }
    }
}
