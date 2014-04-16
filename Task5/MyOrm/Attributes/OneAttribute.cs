using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrm.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class OneAttribute: RelationAttribute
    {
        public OneAttribute()
        {
            this.Type = RelationType.One;
        }
    }
}
