using System;
using System.Collections.Generic;

namespace Acme.IssueManagement.Samples
{
    public class Response
    {
        public int total { get; set; }
        public List<Items> items { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

    }

    public class Items
    {
        public string id { get; set; }
        public string createdBy { get; set; }
        public string lastModifiedBy { get; set; }
        public string Status { get; set; }
        public string StatusColor { get; set; }
        public string SchemaName { get; set; }
        public Data data { get; set; }

    }
    public class Data
    {
        public Data(Id id, UserId userid, Title title, IsCompleted iscompleted)
        {
            this.id = id;
            this.userid = userid;
            this.title = title;
            this.iscompleted = iscompleted;
        }

        public Id id { get; set; }
        public UserId userid { get; set; }
        public Title title { get; set; }
        public IsCompleted iscompleted { get; set; }
    }
    public class Id
    {
        public Id(int iv) 
        {
            this.iv = iv;
        }
        public int iv { get; set; }
    }
    public class UserId
    {
        public UserId(int iv)
        {
            this.iv = iv;
        }
        public int iv { get; set; }
    }
    public class Title
    {
        public Title(string iv)
        {
            this.iv = iv;
        }
        public string iv { get; set; }
    }
    public class IsCompleted
    {
        public IsCompleted(bool iv)
        {
            this.iv = iv;
        }
        public bool iv { get; set; }
    }
}