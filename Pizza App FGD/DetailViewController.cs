using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Pizza_App_FGD
{
    public partial class DetailViewController : UIViewController
    {
        public Pizza currentPizza;
        public List<Pizza> pizzaList;
        public TablePizzaController tablePizzaController;

        public DetailViewController(IntPtr handle) : base(handle)
        {
        }

        public DetailViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (currentPizza != null)
                fillTextFields(currentPizza);

            btnSave400.TouchUpInside += BtnSave_TouchUpInside;
        }

        private void fillTextFields(Pizza currentPizza)
        {
            txtIngredient1.Text = currentPizza.gsIngredient1;
            txtIngredient2.Text = currentPizza.gsIngredient2;
            txtIngredient3.Text = currentPizza.gsIngredient3;
            txtIngredient4.Text = currentPizza.gsIngredient4;
            txtName.Text = currentPizza.gsName;
        }

        private void BtnSave_TouchUpInside(object sender, EventArgs e)
        {
            bool newPerson = false;
            //int index = TablePersonController.listPerson.IndexOf(currentPerson);
            if (currentPizza == null)
            {
                currentPizza = new Pizza("new");
                newPerson = true;
            }
            currentPerson.vorname = txtVorname.Text;
            currentPerson.nachname = txtNachname.Text;
            currentPerson.strasse = txtStrasse.Text;
            currentPerson.plz = txtPLZ.Text;
            currentPerson.ort = txtOrt.Text;

            if (newPerson)
                pizzaList.Add(currentPerson);

            tablePizzaController.NavigationController.PopToRootViewController(true);
            //tablePersonController.NavigationController.PopToViewController("identifier", true);
        }
    }
}