using Hackathon.Feature.ServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Feature.ServiceAPI.Repository
{
    interface IServiceRepository
    {
        bool TriggerGoals(EmailIntents list);
    }
}
