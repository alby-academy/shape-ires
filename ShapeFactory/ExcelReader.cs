using System;
using System.Data;
using ExcelDataReader;
using ShapeFactory.Domain;

namespace ShapeFactory
{
	public class ExcelReader
	{
        
		public ExcelReader() {}

		public IEnumerable<Shape> Read (string path)
		{
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    var dataTable = result.Tables[0];
                    List<Shape> shapes = new List<Shape>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        double id = (double)row[0];
                        double angle = (double)row[1];
                        yield return (new Shape((int)id, (int)angle));
                    }
                }
            }
        }
	}
}

