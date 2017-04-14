using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NLayerApp.ViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceViewModel.ResourceView),ErrorMessageResourceName = "ErrorMessageEmty")]
        [Display(Name = "NameItem", ResourceType = typeof(ResourceViewModel.ResourceView))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceViewModel.ResourceView), ErrorMessageResourceName = "ErrorMessageEmty")]
        [Display(Name = "DescriptionItem", ResourceType = typeof(ResourceViewModel.ResourceView))]
        public string Description { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceViewModel.ResourceView), ErrorMessageResourceName = "ErrorMessageEmty")]
        [Display(Name = "SumItem", ResourceType = typeof(ResourceViewModel.ResourceView))]
        public int Sum { get; set; }

    }
}
