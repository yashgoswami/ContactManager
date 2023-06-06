using ContactManager.Application.Contracts.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.Contracts
{
    public interface IUnitOfWork
    {
        IContactRepository ContactRepository { get; }
    }
}
