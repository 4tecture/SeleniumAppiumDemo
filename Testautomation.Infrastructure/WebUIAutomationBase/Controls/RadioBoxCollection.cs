using System;
using System.Collections.Generic;
using System.Linq;

namespace WebUIAutomationBase.Controls
{
    public class RadioBoxCollection
    {
        private IList<RadioBox> radioBoxes;

        public RadioBoxCollection(RadioBox[] rbCollection)
        {
            this.radioBoxes = new List<RadioBox>();

            if (rbCollection == null) throw new ArgumentNullException(nameof(rbCollection));

            foreach (var radioBox in rbCollection)
            {
                if (radioBox == null) throw new ArgumentNullException(nameof(radioBox));
                this.radioBoxes.Add(radioBox);
            }
        }

        public string GetSelectedId()
        {
            return radioBoxes.FirstOrDefault(r => r.IsSelected())?.GetId();
        }

        public string GetSelectedValue()
        {
            return radioBoxes.FirstOrDefault(r => r.IsSelected())?.GetValue();
        }

        public void SelectById(string id)
        {
            var target = radioBoxes.FirstOrDefault(r => r.GetId().Equals(id));
            if (target == null) throw new ArgumentException($"An radio box option with id {id} does not exist.");
            target.Select();
        }

        public void SelectByValue(string value)
        {
            var target = radioBoxes.FirstOrDefault(r => r.GetValue().Equals(value));
            if (target == null) throw new ArgumentException($"A radio box option with value {value} does not exist.");
            target.Select();
        }
    }
}
