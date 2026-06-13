namespace UnitConverter.Services;

public class ConversionService
{
    public double Convert(string category,string fromUnit,string toUnit,double value)
    {
        switch(category.ToLower())
        {
            case "length": return ConvertLength(fromUnit,toUnit,value);
            case "weight": return ConvertWeight(fromUnit,toUnit,value);
            case "temperature": return ConvertTemperature(fromUnit,toUnit,value);
            default: throw new ArgumentException("Unsupported category");
        }
    }

    private double ConvertLength(string fromUnit,string toUnit,double value)
    {
        var units = new Dictionary<string,double>(StringComparer.OrdinalIgnoreCase)
        {
            {"meter",1},{"kilometer",1000},{"feet",0.3048},{"inch",0.0254}
        };

        if(!units.ContainsKey(fromUnit)) throw new ArgumentException($"Unsupported unit: {fromUnit}");
        if(!units.ContainsKey(toUnit)) throw new ArgumentException($"Unsupported unit: {toUnit}");

        return (value * units[fromUnit]) / units[toUnit];
    }

    private double ConvertWeight(string fromUnit,string toUnit,double value)
    {
        var units = new Dictionary<string,double>(StringComparer.OrdinalIgnoreCase)
        {
            {"kilogram",1},{"gram",0.001},{"pound",0.45359237}
        };

        if(!units.ContainsKey(fromUnit)) throw new ArgumentException($"Unsupported unit: {fromUnit}");
        if(!units.ContainsKey(toUnit)) throw new ArgumentException($"Unsupported unit: {toUnit}");

        return (value * units[fromUnit]) / units[toUnit];
    }

    private double ConvertTemperature(string fromUnit,string toUnit,double value)
    {
        double celsius;

        switch(fromUnit.ToLower())
        {
            case "celsius": celsius = value; break;
            case "fahrenheit": celsius = (value - 32) * 5 / 9; break;
            case "kelvin": celsius = value - 273.15; break;
            default: throw new ArgumentException($"Unsupported unit: {fromUnit}");
        }

        switch(toUnit.ToLower())
        {
            case "celsius": return celsius;
            case "fahrenheit": return (celsius * 9 / 5) + 32;
            case "kelvin": return celsius + 273.15;
            default: throw new ArgumentException($"Unsupported unit: {toUnit}");
        }
    }
}