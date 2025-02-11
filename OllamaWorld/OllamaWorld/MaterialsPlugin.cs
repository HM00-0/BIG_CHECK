using Microsoft.SemanticKernel;
using OllamaWorld;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollamaworld
{
    public class MaterialsPlugin
    {
        private readonly List<MaterialsModel> _mat = new ()
        {
            new MaterialsModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Steel_bar",
                Company = "CompanyA",
                Unit = "kg",
                Amount = 100,
                IsArrived = true,
                IsUsed = false,
                Place_sector = 'A'
            },
            new MaterialsModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Aluminium_panel",
                Company = "CompanyB",
                Unit = "EA",
                Amount = 50,
                IsArrived = true,
                IsUsed = false,
                Place_sector = 'B'
            },
            new MaterialsModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Copper_panel",
                Company = "CompanyC",
                Unit = "kg",
                Amount = 100,
                IsArrived = false,
                IsUsed = false,
                Place_sector = 'A'
            }
        };

        [KernelFunction("get_materials")]
        [Description("Get a list of materials and their current state")]
        [return: Description("List of cars")]
        public async Task< List<MaterialsModel>> GetMaterialsAsync()
        {
            return _mat;
        }

        [KernelFunction("get_materials_info")]
        [Description("Get the information about a material by its name")]
        [return: Description("Information about the material")]
        public async Task<MaterialsModel> GetMaterialsInfoAsync([Description("The name of the material")] string name)
        {
            return _mat.FirstOrDefault( _mat => _mat.Name == name);
        }


        [KernelFunction("change_state")]
        [Description("Change the state of a material by its name")]
        [return: Description("New state of the material")]
        public async Task<MaterialsModel> ChangeStateAsync(string name, bool IsArrived)
        {
            var mat = _mat.FirstOrDefault(m => m.Name == name);
            if (mat == null)
            {
                return null;
            }

            mat.IsArrived = !mat.IsArrived;
            return mat;

        }
    }
}