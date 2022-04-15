using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arvind.EmailService
{
    public interface IEmailSender
    {       
        Task SendEmailAsync(Message message);
        bool SendEmail(Message message);
    }
}
