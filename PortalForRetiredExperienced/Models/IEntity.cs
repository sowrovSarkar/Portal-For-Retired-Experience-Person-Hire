using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalForRetiredExperienced.Models
{
    public interface IEntity<Tkey>
    {
        Tkey Id { get; set; }
    }
}
