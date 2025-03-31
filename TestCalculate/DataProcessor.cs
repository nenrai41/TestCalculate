using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculate
{
    class DataProcessor
    {
        private static DataProcessor calculateObject;
        public  CoordinatesOfСompartment CoordinatesOfEquipment { get; private set; }
        public  CoordinatesOfСompartment CoordinatesOfEngineSystem { get; private set; }
        public  CoordinatesOfСompartment CoordinatesOfPayload { get; private set; }
        public  CoordinatesOfСompartment CoordinatesOfWing { get; private set; }
        public  CoordinatesOfСompartment CoordinatesOfRudders { get; private set; }

        private DataProcessor()
        { }

        public static DataProcessor GetCalculateObject()
        {
            if (calculateObject == null)
            {
                calculateObject = new DataProcessor();
            }   
            return calculateObject;
        }
        private bool IsInitialized = false;
        public void Initialazing()
        {
            if (!IsInitialized)
            {
                CoordinatesOfEquipment = new CoordinatesOfСompartment(0f, 0f);
                CoordinatesOfEngineSystem = new CoordinatesOfСompartment(0f, 0f);
                CoordinatesOfPayload = new CoordinatesOfСompartment(0f, 0f);
                CoordinatesOfWing = new CoordinatesOfСompartment(0f, 0f);
                CoordinatesOfRudders = new CoordinatesOfСompartment(0f, 0f);
                IsInitialized = true;
            }
            
        }

        //public void SetParametr(float payloadMass, float relativePayloadMass, float relativeMassOfEquipment, float relativeMassOfEngineSystem, float relativeFuselageLength, float fuselageDiametr, float cruisingSpeed, float densityOfEquipmentLayout, float densityOfPayloadLayout,float densityOfEngineSystemLayout)
        //{
            
        //}


        //public float RelativePayloadMass { get; private set; } = 0f;
        //public float RelativeMassOfEquipment { get; private set; } = 0f;
        //public float RelativeMassOfEngineSystem { get; private set; } = 0f;
       

        
        public float StartingMass { get; private set; } = 0f;
        public float PayloadMass { get; private set; } = 0f;
        public float MassOfEngineSystem { get; private set; } = 0f;
        public float MassOfEquipment { get; private set; } = 0f;
        

        public bool CalculateOfMass(float payloadMass, float relativePayloadMass, float relativeMassOfEquipment, float relativeMassOfEngineSystem)
        {
            if((relativePayloadMass + relativeMassOfEngineSystem + relativeMassOfEngineSystem) == 1 && payloadMass != 0)
            {
                StartingMass = payloadMass / relativePayloadMass;
                PayloadMass = payloadMass;
                MassOfEquipment = StartingMass * relativeMassOfEquipment;
                MassOfEngineSystem = StartingMass * relativeMassOfEngineSystem;
                return true;
            }
            else
            {
                return false;
            }
            
        }

              
        public float FuselageDiametr { get; private set; } = 0f;
        public float FuselageLength { get; private set; } = 0f;


        public bool CalculateOfFuselageLength(float relativeFuselageLength, float fuselageDiametr)
        {
            if(relativeFuselageLength != 0 && fuselageDiametr != 0)
            {
                FuselageDiametr = fuselageDiametr;
                FuselageLength = relativeFuselageLength * FuselageDiametr;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public float CruisingSpeed { get; private set; } = 0f;
        public float LiftOfWing { get; private set; } = 0f;
        public float LiftOfRubbers { get; private set; } = 0f;


        public float AreaOfWing { get; private set; } = 0f;
        public float SpanOfWing { get; private set; } = 0f;
        public float AreaOfRudders { get; private set; } = 0f;
        public float SpanOfRudders { get; private set; } = 0f;

        public bool CalculateOfAreaAndSpan(float cruisingSpeed)
        {
            if (cruisingSpeed != 0)
            {
                CruisingSpeed = cruisingSpeed;
                LiftOfWing = 0.9f * (StartingMass * 9.82f);
                AreaOfWing = (2.0f * LiftOfWing) / (ConstantOfParametr.AIRDENSITY * MathF.Pow(cruisingSpeed, 2) * ConstantOfParametr.COEFFICIENTOFLIFTOGWING);
                SpanOfWing = AreaOfWing / ConstantOfParametr.CHORDOFWING;

                LiftOfRubbers = 0.1f * (StartingMass * 9.82f);
                AreaOfRudders = (2.0f * LiftOfRubbers) / (ConstantOfParametr.AIRDENSITY * MathF.Pow(CruisingSpeed, 2) * ConstantOfParametr.COEFFICIENTOFLIFTOGRUDDER);
                SpanOfRudders = AreaOfRudders / ConstantOfParametr.CHORDOFRUDDER;
                return true;
            }
            else
            {
                return false;
            }
             
        }

        //public float DensityOfEquipmentLayout { get; private set; } = 0f;
        //public float DensityOfPayloadLayout { get; private set; } = 0f;
        //public float DensityOfEngineSystemLayout { get; private set; } = 0f;


        public float LengthOfEquipment { get; private set; } = 0f;
        public float LengthOfPayload { get; private set; } = 0f;
        public float LengthOfEngineSystem { get; private set; } = 0f;
        

        public bool CalculateLengthOfCompartments(float densityOfEquipmentLayout, float densityOfPayloadLayout, float densityOfEngineSystemLayout)
        {
            if (densityOfEquipmentLayout != 0 && densityOfPayloadLayout != 0  && densityOfEngineSystemLayout != 0)
            {
                LengthOfEquipment = (3.0f * MassOfEquipment) / (densityOfEquipmentLayout * MathF.PI * MathF.Pow((FuselageDiametr / 2), 2));
                LengthOfEngineSystem = (MassOfEngineSystem) / (densityOfEngineSystemLayout * MathF.PI * MathF.Pow((FuselageDiametr / 2), 2));
                LengthOfPayload = (PayloadMass) / (densityOfPayloadLayout * MathF.PI * MathF.Pow((FuselageDiametr / 2), 2));

                calculateObject.CoordinatesOfEquipment = new CoordinatesOfСompartment(0f, LengthOfEquipment);
                calculateObject.CoordinatesOfPayload = new CoordinatesOfСompartment(LengthOfEquipment, LengthOfEquipment + LengthOfPayload);
                calculateObject.CoordinatesOfEngineSystem = new CoordinatesOfСompartment(LengthOfEquipment + LengthOfPayload, LengthOfEquipment + LengthOfPayload + LengthOfEngineSystem);
                return true;
            }
            else
            {
                return false;
            }

            
        }
        public float CentrOfMassOfEquipment { get; private set; } = 0f;
        public float CentrOfMassOfPayload { get; private set; } = 0f;
        public float CentrOfMassOfEngineSystem { get; private set; } = 0f;

        public void CalculateOfCentrOfMassOfCompartments()
        {
            CentrOfMassOfEquipment = (CoordinatesOfEquipment.EndOfCompartment * 3.0f) / 4.0f;
            CentrOfMassOfPayload = (CoordinatesOfPayload.StartOfCompartment + CoordinatesOfPayload.EndOfCompartment) / 2.0f;
            CentrOfMassOfEngineSystem = (CoordinatesOfEngineSystem.StartOfCompartment + CoordinatesOfEngineSystem.EndOfCompartment) / 2.0f;
        }

       
        public float CentrOfMassOfWing { get; private set; } = 0f;
        public float CentrOfPressureOnTheWing { get; private set; } = 0f;
        public void CalculateOfCenterOfMassOfWing()
        {
            calculateObject.CoordinatesOfWing = new CoordinatesOfСompartment((0.8f * LengthOfEngineSystem) - ConstantOfParametr.CHORDOFWING, 0.8f * LengthOfEngineSystem);
            CentrOfMassOfWing = (CoordinatesOfWing.StartOfCompartment + CoordinatesOfWing.EndOfCompartment)/ 2.0f;
        }


        public void CalculateOfCenterOfPressureOnWing()
        {
            CentrOfPressureOnTheWing = CoordinatesOfWing.StartOfCompartment + 0.25f * ConstantOfParametr.CHORDOFWING;
        }

        public float CentrOfPressureOnTheRudders { get; private set; } = 0f;

        public void CalculateOfCenterOfMassOfRudders()
        {
            CoordinatesOfRudders = new CoordinatesOfСompartment(0.1f * FuselageLength, (0.1f * FuselageLength) + ConstantOfParametr.CHORDOFRUDDER);
        }


        public void CalculateOfCenterOfPressureOnRudders()
        {
            CentrOfPressureOnTheRudders = CoordinatesOfRudders.StartOfCompartment + 0.25f * ConstantOfParametr.CHORDOFRUDDER;
        }

        public float CentrOfPressureOnTheUAVs { get; private set; } = 0f;
        public float CentrOfMassOfUAVs { get; private set; } = 0f;
        public void CalculateOfCentrOfPressureOnUAVs()
        {
            CentrOfPressureOnTheUAVs = (AreaOfWing * CentrOfPressureOnTheWing + AreaOfRudders * CentrOfPressureOnTheRudders) / (AreaOfWing + AreaOfRudders);
        }

        public void CalculateOfCentrOfCenterOfMassOfUAVs()
        {
            CentrOfMassOfUAVs = (MassOfEquipment*CentrOfMassOfEquipment+MassOfEngineSystem*CentrOfMassOfEngineSystem+PayloadMass*CentrOfMassOfPayload)/StartingMass;
        }

    }
    struct CoordinatesOfСompartment
    {
        public float StartOfCompartment;
        public float EndOfCompartment;
        public CoordinatesOfСompartment(float startOfCompartment, float endOfCompartment)
        {
            StartOfCompartment = startOfCompartment;
            EndOfCompartment = endOfCompartment;
        }
        
    }

}
