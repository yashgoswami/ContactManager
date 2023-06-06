using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.DTOs;

public record EditContactInput(int Id, string FirstName, string LastName, string Email, string PhoneNumber, string Status);
