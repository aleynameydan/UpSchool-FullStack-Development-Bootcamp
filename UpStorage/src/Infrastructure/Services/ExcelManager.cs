using Application.Common.Interfaces;
using Application.Common.Models.Excel;
using ExcelMapper;

namespace Infrastructure.Services;

public class ExcelManager: IExcelService
{
    public List<ExcelCityDto> ReadCities(ExcelLoadDto excelDto)
    {
        var fileBytes = Convert.FromBase64String(excelDto.File);


        using var stream = new MemoryStream(fileBytes);
        using var importer = new ExcelImporter(stream);

        ExcelSheet sheet = importer.ReadSheet();
        var cityDtos = sheet.ReadRows<ExcelCityDto>().ToList();

        return cityDtos;
    }

    public List<ExcelCountryDto> ReadCountries(ExcelBase64Dto excelDto)
    {
        // We convert base64string to byte[]
        
        
    }


}