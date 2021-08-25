using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_.model;
using MVC_.model.entity;
using MVC_.view;

namespace MVC_.controller
{
    public class Controller
    {
        private Model model;
        private View view;
        private List<object> obj;
        public Controller(Model model, View view)
        {
            this.model = model;
            this.view = view;
        }

       public void operation()
        {

            

            obj = model.getObjList();


            foreach (EntityWithDelegate row in obj)
            {
                row.display();
                //....


            }
            

        }
    
   
    }
}
