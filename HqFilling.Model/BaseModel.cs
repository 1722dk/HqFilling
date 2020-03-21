using System;

namespace HqFilling.Model
{
    public class BaseModel
    {
        public virtual int UserId { get; set; }
        public virtual int SessionId { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string DbAction { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}
