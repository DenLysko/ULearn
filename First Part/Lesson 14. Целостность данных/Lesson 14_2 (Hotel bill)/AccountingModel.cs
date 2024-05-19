using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HotelAccounting;

public class AccountingModel : ModelBase
{
    private int nightsCount;

    private double total;
    public double Price 
    {
        get { return Price; }
        set
        {
            SetWithNotify(Price, value);
        } 
    }
    public int NightsCount
    {
        get { return NightsCount; }
        set
        {
            if (value <= 0)
                throw new ArgumentException();
            SetWithNotify(NightsCount, value);
        }
    }
    
    public double Discount 
    {
        get { return Discount; }
        set
        {
            SetWithNotify(Discount, value);
        } 
    }

    public double Total
    {
        get { return total; }
        set
        {
            if (value < 0)
                throw new ArgumentException();
            SetWithNotify(Total, value);
        }
    }

    private void SetWithNotify(object property, object value)
    {
        property = value;
        Notify(nameof(property));
    }
}