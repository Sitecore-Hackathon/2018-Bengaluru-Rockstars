using Hackathon.Feature.XConnectUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Feature.XConnectUtility.Repository
{
    interface IServiceRepository
    {
        bool TriggerGoals(EmailIntent emailIntent);
    }
}
