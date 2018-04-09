using NUnit.Framework;
using System.Reflection;
using System;
using System.Linq;

namespace DatabaseTests
{
[TestFixture]
public class DatabaseTests
{
    private const int InputNumber = 6;

    [Test]
    [TestCase(new int[] { 1, 2, 3, 4 })]
    [TestCase(new int[] { 999, 0, 4 })]
    [TestCase(new int[] { -555 })]
    [TestCase(new int[] { })]
    public void TestValidConstructor(int[] initialArray)
    {
        // int[] initialArray = new int[] { 1, 2, 3, 4 };
        var db = new Database(initialArray);

        FieldInfo fieldInfpo = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .First(fi => fi.FieldType == typeof(int[]));

        //var actualValues = ((int[])fieldInfpo.GetValue(db))
        //.Take(initialArray.Length);

        var actualValues = ((int[])fieldInfpo.GetValue(db));
        int[] buffer = new int[actualValues.Length - initialArray.Length];

        // за сравняване на колекции по ред, брой, ...:
        Assert.That(actualValues, Is.EquivalentTo(initialArray.Concat(buffer)));
    }

    [Test]
    public void TestInvalidConstructor()
    {
        int[] initialArray = new int[17];

        Assert.That(() => new Database(initialArray), Throws.InvalidOperationException);
    }


    [Test]
    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    [TestCase(0)]
    [TestCase(-50)]
    public void AddMethodValid(int inputValue)
    {
        var db = new Database();
        db.Add(inputValue);

        FieldInfo valuesdInfo = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(fi => fi.FieldType == typeof(int[])); // за field values

        FieldInfo currentIndexInfo = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(fi => fi.FieldType == typeof(int)); // за field currentIndex

        var expectedValue = ((int[])valuesdInfo.GetValue(db)).First();
        Assert.That(expectedValue, Is.EqualTo(inputValue));

        var valuesCount = ((int)currentIndexInfo.GetValue(db));
        Assert.That(valuesCount, Is.EqualTo(1));

    }

    [Test]
    public void AddMethodInvalidCase()
    {
        // Var.1: - ползвайки ctor:
        //int[] initialArray = new int[16];
        //Database db = new Database(initialArray);
        //Assert.That(() => db.Add(5), Throws.InvalidOperationException);

        // Var.2: - без ctor - с custom Mocking:
        Database db = new Database();
        // Можем и за тестовете да дадем стс-ст на currentIndex да е 16:
        FieldInfo currentIndexInfo = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(fi => fi.FieldType == typeof(int)); // за field currentIndex

        currentIndexInfo.SetValue(db, 16);

        Assert.That(() => db.Add(1), Throws.InvalidOperationException);
    }

    [Test]
    [TestCase(new int[] { 1, 2, 3, 4 })]
    [TestCase(new int[] { 999, 0, 4 })]
    [TestCase(new int[] { -555 })]
    public void TestRemoveMethodValid(int[] values)
    {
        // за да не ползваме ctor-a и другите методи, задаваме ст-сти на полетата currentIndex и values:
        var db = new Database();

        FieldInfo fieldInfo = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .First(fi => fi.FieldType == typeof(int[]));

        fieldInfo.SetValue(db, values);

        FieldInfo currentIndexInfo = typeof(Database)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(fi => fi.FieldType == typeof(int)); // за field currentIndex

        currentIndexInfo.SetValue(db, values.Length);

        db.Remove();

        var actualValues = ((int[])fieldInfo.GetValue(db));
        int[] buffer = new int[actualValues.Length - (values.Length - 1)];

        values = values.Take(values.Length - 1).Concat(buffer).ToArray();
        Assert.That(actualValues, Is.EquivalentTo(values));

    }

    [Test]
    public void RemoveMethodInvalidTest()
    {
        var db = new Database();

        FieldInfo currentIndexInfo = GetField(db, typeof(int));
        currentIndexInfo.SetValue(db, 0);

        Assert.That(() => db.Remove(), Throws.InvalidOperationException);
    }


    private FieldInfo GetField(object instance, Type fieldType)
    {
        FieldInfo currentIndexInfo = instance.GetType()
        .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
        .First(fi => fi.FieldType == typeof(int)); // за field currentIndex

        return currentIndexInfo;
    }

    [Test]
    public void FetchMethodValid()
    {
        int[] inputArray = { 5, 4, 3 };

        var db = new Database(inputArray);

        // Assert.That(db.Fetch(), Is.EquivalentTo(inputArray)); // or
        CollectionAssert.AreEqual(inputArray, db.Fetch());
    }
}
}
