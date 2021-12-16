namespace Kennel.Models
{
    public class Treatment
    {
        private TreatmentType _treatmentType;

        public int Id { get; set; }
        public TreatmentType TreatmentType
        {
            get { return _treatmentType; }
            set { _treatmentType = value; }
        }
        public decimal Price 
        { 
            get 
            { 
                switch (_treatmentType)
                {
                    case TreatmentType.Wash:
                        return 299;
                    case TreatmentType.TrimClaws:
                        return 149;
                    default:
                        return 100;
                }
            } 
        }
    }

    public enum TreatmentType
    {
        Wash = 0,
        TrimClaws = 1
    }
}
