using EchoApplication.Helper;
using EchoApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoApplication.ModalWindow.ViewModel
{
    class CalculationWindowModel : NotifyProperty
    {
        private ProjectData _projectData;
        public ProjectData projectData
        {
            get { return _projectData; }
            set
            {
                _projectData = value;
                OnPropertyChanged(nameof(projectData));
            }
        }


        public CalculationWindowModel(ProjectData _ProjectData)
        {
            projectData = _ProjectData;
        }
    }
}
