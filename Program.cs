Console.WriteLine();

// building a car without director
SportCarBuilder sportyCarBuilder = new SportCarBuilder();
sportyCarBuilder.Step1();
sportyCarBuilder.Step2();
sportyCarBuilder.Step3();
var res = sportyCarBuilder.GetResult();

// cases by using director
Director d = new(sportyCarBuilder);
d.ConstructSportsCar();

d.SetNewBuilder(new SportCarManualBuilder());
d.ConstructSportsCarManual();


interface IBuilder
{
    void Step1();
    void Step2();
    void Step3();    
    void Reset();
}

class Director
{
    private IBuilder _builder;
    public Director(IBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructSportsCar()
    {        
        _builder.Reset();
        _builder.Step1();
        _builder.Step2();
        _builder.Step3();
    }

    public void ConstructSportsCarManual()
    {
        _builder.Reset();
        _builder.Step1(); //assume in this case we don't need step 2
        _builder.Step3();
        //can contain more or less steps
    }

    public void SetNewBuilder(IBuilder builder)
    {
        _builder = builder;
    }
}

class SportCarBuilder : IBuilder
{
    private Car _product;

    public SportCarBuilder()
    {
        _product = new Car();
    }

    public Car GetResult()
    {
        return _product;
    }

    public void Reset()
    {
        _product = new Car();
    }

    public void Step1()
    {
        _product.Doors = new List<string>() { "door1", "door2" };
    }

    public void Step2()
    {
        _product.Wheels = new List<string>() { "wheel1", "wheel2" };

    }

    public void Step3()
    {
        _product.StearingWheel = "sporty stearing wheel";
    }
}

class SportCarManualBuilder : IBuilder
{
    private CarManual _product;

    public SportCarManualBuilder()
    {
        _product = new CarManual();
    }

    public CarManual GetResult()
    {
        return _product;
    }

    public void Reset()
    {
        _product = new CarManual();
    }

    public void Step1()
    {
        _product.Doors = new List<string>() { "door1_manual", "door2_manual" };
    }

    public void Step2()
    {
        _product.Wheels = new List<string>() { "wheel1_manual", "wheel2_manual" };

    }

    public void Step3()
    {
        _product.StearingWheel = "sporty stearing wheel buttons manual";
    }
}

class Car
{
    public List<string> Wheels { get; set; }
    public List<string> Doors { get; set; }
    public string StearingWheel { get; set; }
}

class CarManual
{
    public List<string> Wheels { get; set; }
    public List<string> Doors { get; set; }
    public string StearingWheel { get; set; }
}