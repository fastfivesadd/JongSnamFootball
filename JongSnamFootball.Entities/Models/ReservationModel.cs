using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class ReservationModel : BaseModel
    {
        public int StoreId { get; set; }

        public int UserId { get; set; }

        public int FieldId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime StopTime { get; set; }

        public bool ApprovalStatus { get; set; }

        public bool Active { get; set; }

        public virtual UserModel UserModel { get; set; }

        public virtual StoreModel StoreModel { get; set; }

        public virtual FieldModel FieldModel { get; set; }

        public virtual PaymentModel PaymentModel { get; set; }

    }
}
