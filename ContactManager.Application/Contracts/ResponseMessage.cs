using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.Contracts
{
    public abstract class ResponseMessage
    {
        public bool IsCreated { get; private set; }
        public string? Message { get; private set; }
        public int? Id { get; private set; }

        protected ResponseMessage(bool isCreated, string? message = null, int? id = null)
        {
            this.IsCreated = isCreated;
            this.Message = message;
            this.Id = id;
        }
    }
}
