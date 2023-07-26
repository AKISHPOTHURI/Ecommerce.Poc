using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Api.Model
{
    public partial class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int? ManagerId { get; set; }
        public int? ParentDeptId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
