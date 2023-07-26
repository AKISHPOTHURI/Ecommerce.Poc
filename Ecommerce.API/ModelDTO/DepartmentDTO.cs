namespace Ecommerce.Api.ModelDTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DepartmentDTO
    {
      //  [DeptID]
      //,[DeptName]
      //,[ManagerID]
      //,[ParentDeptID]
      //,[ValidFrom]
      //,[ValidTo]
      public int DeptID { get; set; }
      public string DeptName { get; set; }
      public int ManagerID { get; set; }
      public int ParentDeptID { get; set; }
      public int ValidFrom { get; set; }
      public int ValidTo { get; set; }
    }
}
