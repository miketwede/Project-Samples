using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sqo;
using Example.DataObjects;

namespace Example
{
    class AllTypesOfFieldsSupportedExample : BaseExample, IExample
    {
        //siaqodb support as members of a storable class following  basic/primitive  types:
        //**********************************************************************
        //int,uint,short,string,ushort,byte,sbyte,long,ulong,float,double,decimal,char,
        //bool,TimeSpan,DateTime,Guid, enum
        //************************************************************************

        //siaqodb support as members of a storable class also nested objects,arrays, IList and Dictionary<T,V>
        
       
        public void Run()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();
            //clear all objects of Type BigClass created by previous run of app
            siaqodb.DropType<BigClass>();

            BigClass big = new BigClass();
            big.employees = new List<Employee>(new Employee[] { new Employee() });
            big.nestedObject = new BigClass();
            big.myDictionary = new Dictionary<int, string>();
            big.myDictionary.Add(1, "test");
            big.listOfComplexObjects = new List<BigClass>(new BigClass[] { new BigClass() });
            
            siaqodb.StoreObject(big);
            
            IObjectList<BigClass> list = siaqodb.LoadAll<BigClass>();

            

           
        }
    }
    public class BigClass 
    {
       
        public int i;
        public uint iu;
        public short s;
        public string str = "test";
        public ushort us;
        public byte b;
        public sbyte sb;
        public long l;
        public ulong ul;
        public float f;
        public double d;
        public decimal de;
        public char c='k';
        public bool bo;
        public TimeSpan ts;
        public DateTime dt;
        public Guid g;
        public TestEnum enn = TestEnum.Two;
        public int[] intArray;
        public List<int> intList;
        public Dictionary<int, string> myDictionary;
        public BigClass nestedObject;
        public Employee nestedEmployee=new Employee();

        public List<BigClass> listOfComplexObjects;

        public List<Employee> employees;


    }
    public enum TestEnum { One,Two}
}
