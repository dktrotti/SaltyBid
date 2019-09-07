using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Input
{
    [RequireComponent(typeof(AutoRotator))]
    public class InputTranslator : MonoBehaviour
    {
        private AutoRotator autoRotator;

        // Start is called before the first frame update
        void Start()
        {
            autoRotator = GetComponent<AutoRotator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public InputSequence Translate(RelativeInputSequence sequence)
        {
            var facingRight = autoRotator.FacingRight();
            return new InputSequence(sequence.Inputs.Select(i => new Input(i, facingRight)));
        }
    }
}
