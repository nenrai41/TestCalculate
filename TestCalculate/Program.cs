using TestCalculate;


//Console.WriteLine("Пожалуйста введите константы");

//Console.WriteLine("Плотность воздуха: ");
//string AIRDENSITY = Console.ReadLine();
//ConstantOfParametr.AIRDENSITY = ManipulationClass.ConvertTo(AIRDENSITY);

//Console.WriteLine("Хорда крыла: ");
//string CHORDOFWING = Console.ReadLine();
//ConstantOfParametr.CHORDOFWING = ManipulationClass.ConvertTo(CHORDOFWING);

//Console.WriteLine("Хорда руля: ");
//string CHORDOFRUDDER = Console.ReadLine();
//ConstantOfParametr.CHORDOFRUDDER = ManipulationClass.ConvertTo(CHORDOFRUDDER);

//Console.WriteLine("Коэффициент подъемной силы крыла: ");
//string COEFFICIENTOFLIFTOGWING = Console.ReadLine();
//ConstantOfParametr.COEFFICIENTOFLIFTOGWING = ManipulationClass.ConvertTo(COEFFICIENTOFLIFTOGWING);

//Console.WriteLine("Коэффициент подъемной силы руля: ");
//string COEFFICIENTOFLIFTOGRUDDER = Console.ReadLine();
//ConstantOfParametr.COEFFICIENTOFLIFTOGRUDDER = ManipulationClass.ConvertTo(COEFFICIENTOFLIFTOGRUDDER);


ConstantOfParametr.AIRDENSITY = 1.2754f; //метры кг/м^3
ConstantOfParametr.CHORDOFWING = 2.5f; //метры 
ConstantOfParametr.CHORDOFRUDDER = 1.0f; //метры 
ConstantOfParametr.COEFFICIENTOFLIFTOGWING = 0.8f;
ConstantOfParametr.COEFFICIENTOFLIFTOGRUDDER = 0.95f;


float relativePayloadMass = 0.4f; 
float relativeMassOfEquipment = 0.3f;
float relativeMassOfEngineSystem = 0.3f;
float payloadMass = 30.0f; //кг 

//Console.WriteLine("Введите относительную массу ПН: ");
//string relativePayloadMassStr = Console.ReadLine();
//float relativePayloadMass = ManipulationClass.ConvertTo(relativePayloadMassStr);

//Console.WriteLine("Введите относительную массу аппаратуры: ");
//string relativeMassOfEquipmentStr = Console.ReadLine();
//float relativeMassOfEquipment = ManipulationClass.ConvertTo(relativeMassOfEquipmentStr);

//Console.WriteLine("Введите относительную массу ДУ: ");
//string relativeMassOfEngineSystemStr = Console.ReadLine();
//float relativeMassOfEngineSystem = ManipulationClass.ConvertTo(relativeMassOfEngineSystemStr);

//Console.WriteLine("Введите массу ПН: ");
//string payloadMassStr = Console.ReadLine();
//float payloadMass = ManipulationClass.ConvertTo(payloadMassStr);

DataProcessor dataProcessor = DataProcessor.GetCalculateObject();
dataProcessor.Initialazing();

dataProcessor.CalculateOfMass(payloadMass, relativePayloadMass, relativeMassOfEquipment, relativeMassOfEngineSystem);


float relativeFuselageLength = 3.0f; //метры 
float fuselageDiametr = 1.1f; //метры 


//Console.WriteLine("Введите относительное удлинение фюзеляжа: ");
//string relativeFuselageLengthStr = Console.ReadLine();
//float relativeFuselageLength = ManipulationClass.ConvertTo(relativeFuselageLengthStr);

//Console.WriteLine("Введите диаметр фюзеляжа: ");
//string fuselageDiametrStr = Console.ReadLine();
//float fuselageDiametr = ManipulationClass.ConvertTo(fuselageDiametrStr);

dataProcessor.CalculateOfFuselageLength(relativeFuselageLength, fuselageDiametr);

//Console.WriteLine("Введите скорость крейсерского полета: ");
//string cruisingSpeedStr = Console.ReadLine();
//float cruisingSpeed = ManipulationClass.ConvertTo(cruisingSpeedStr);

float cruisingSpeed = 33.3f; //метры в секунду

dataProcessor.CalculateOfAreaAndSpan(cruisingSpeed);


float densityOfEquipmentLayout = 0.7f; //м^3
float densityOfEngineSystemLayout = 1.2f; //м^3
float densityOfPayloadLayout = 1.0f; //м^3

//Console.WriteLine("Введите плотность компоновки аппаратуры: ");
//string densityOfEquipmentLayoutStr = Console.ReadLine();
//float densityOfEquipmentLayout = ManipulationClass.ConvertTo(densityOfEquipmentLayoutStr);

//Console.WriteLine("Введите плотность компоновки ДУ: ");
//string densityOfEngineSystemLayoutStr = Console.ReadLine();
//float densityOfEngineSystemLayout = ManipulationClass.ConvertTo(densityOfEngineSystemLayoutStr);

//Console.WriteLine("Введите плотность компоновки ПН: ");
//string densityOfPayloadLayoutStr = Console.ReadLine();
//float densityOfPayloadLayout = ManipulationClass.ConvertTo(densityOfPayloadLayoutStr);

dataProcessor.CalculateLengthOfCompartments(densityOfEquipmentLayout, densityOfPayloadLayout, densityOfEngineSystemLayout);

dataProcessor.CalculateOfCentrOfMassOfCompartments();



dataProcessor.CalculateOfCenterOfMassOfWing();

dataProcessor.CalculateOfCenterOfPressureOnWing();



dataProcessor.CalculateOfCenterOfMassOfRudders();

dataProcessor.CalculateOfCenterOfPressureOnRudders();


dataProcessor.CalculateOfCentrOfCenterOfMassOfUAVs();

dataProcessor.CalculateOfCentrOfPressureOnUAVs();




Console.WriteLine("Относительная масса ПН: " + relativePayloadMass);
Console.WriteLine("Относительная масса ДУ: " + relativeMassOfEngineSystem);
Console.WriteLine("Относительная масса аппаратуры: " + relativeMassOfEquipment);
Console.WriteLine("Масса ПН: " + payloadMass + " кг");
Console.WriteLine("Общая масса: " + dataProcessor.StartingMass + " кг");
Console.WriteLine("Относительное удлинение фюзеляжа: " + relativeFuselageLength + " м");
Console.WriteLine("Диаметр фюзеляжа: " + fuselageDiametr + " м");
Console.WriteLine("Длина фюзеляжа: " + dataProcessor.FuselageLength + " м");
Console.WriteLine("Крейсерская скорость полета: " + cruisingSpeed + " м/c");
Console.WriteLine("Подъемная сила крыла: " + dataProcessor.LiftOfWing + " Н");
Console.WriteLine("Подъемная сила руля: " + dataProcessor.LiftOfRubbers + " Н");
Console.WriteLine("Площадь крыла: " + dataProcessor.AreaOfWing + " м^2");
Console.WriteLine("Размах крыла: " + dataProcessor.SpanOfWing + " м");
Console.WriteLine("Площадь руля: " + dataProcessor.AreaOfRudders + " м^2");
Console.WriteLine("Размах руля: " + dataProcessor.SpanOfRudders + " м");
Console.WriteLine("Длина отсека аппаратуры: " + dataProcessor.LengthOfEquipment + " м");
Console.WriteLine("Длина отсека ДУ: " + dataProcessor.LengthOfEngineSystem + " м");
Console.WriteLine("Длина отсека ПН: " + dataProcessor.LengthOfPayload + " м");

Console.WriteLine("Координаты начала отсека с аппаратурой: " + dataProcessor.CoordinatesOfEquipment.StartOfCompartment + " Координаты конца отсека с аппаратурой: " + dataProcessor.CoordinatesOfEquipment.EndOfCompartment);
Console.WriteLine("Координаты начала отсека с ПН: " + dataProcessor.CoordinatesOfPayload.StartOfCompartment + " Координаты конца отсека с ПН: " + dataProcessor.CoordinatesOfPayload.EndOfCompartment);
Console.WriteLine("Координаты начала отсека с ДУ: " + dataProcessor.CoordinatesOfEngineSystem.StartOfCompartment + " Координаты конца отсека с ДУ: " + dataProcessor.CoordinatesOfEngineSystem.EndOfCompartment);

Console.WriteLine("Центр масс аппаруторного отсека: " + dataProcessor.CentrOfMassOfEquipment);
Console.WriteLine("Центр масс ПН отсека: " + dataProcessor.CentrOfMassOfPayload);
Console.WriteLine("Центр масс ДУ отсека: " + dataProcessor.CentrOfMassOfEngineSystem);

Console.WriteLine("Координаты начала крыльев: " + dataProcessor.CoordinatesOfWing.StartOfCompartment + " Координаты конца крыльев: " + dataProcessor.CoordinatesOfWing.EndOfCompartment);
Console.WriteLine("Центр масс крыла :" + dataProcessor.CentrOfMassOfWing);
Console.WriteLine("Центр давления на крыло: " + dataProcessor.CentrOfPressureOnTheWing);

Console.WriteLine("Координаты начала рулей: " + dataProcessor.CoordinatesOfRudders.StartOfCompartment + " Координаты конца рулей: " + dataProcessor.CoordinatesOfRudders.EndOfCompartment);
Console.WriteLine("Центр давления на рули: " + dataProcessor.CentrOfPressureOnTheRudders);

Console.WriteLine("Центр масс БПЛА: " + dataProcessor.CentrOfMassOfUAVs);
Console.WriteLine("Центр давления на БПЛА: " + dataProcessor.CentrOfPressureOnTheUAVs);

if ((dataProcessor.CentrOfPressureOnTheUAVs - dataProcessor.CentrOfMassOfUAVs) >= (0.05f * dataProcessor.FuselageLength))
{
    Console.WriteLine("Условие усточивости выполнено");
}
else
{
    Console.WriteLine("Условие усточивости невыполнено");
}
public static class ManipulationClass
{
    public static float ConvertTo(string value)
    {
        if (float.TryParse(value, out float _value))
            return _value;
        else
            return 0;
    }
}
