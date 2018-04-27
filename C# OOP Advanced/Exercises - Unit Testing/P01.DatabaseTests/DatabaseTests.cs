using NUnit.Framework;
using P01Database;
using System;
using System.Linq;
using System.Reflection;

namespace P01.DatabaseTests
{
    class DatabaseTests
    {
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        [TestCase(1)]
        [TestCase(9, 10, 11, 12, 13, 14, 15, 16)]
        [TestCase(1, 2, 3)]
        public void Constructor_ConstructorInjection_IntialValuesAreSetValid(params int[] constructorValues)
        {
            Database database = new Database(constructorValues);

            int[] dbValues = GetDataField(database, constructorValues.Length);

            Assert.That(dbValues, Is.EquivalentTo(constructorValues));
        }

        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20)]
        public void Constructor_IntialValuesMoreThan16_ExceptionThrown(params int[] constructorValues)
        {
            Database database;

            Assert.Catch<InvalidOperationException>(() => database = new Database(constructorValues));
        }

        [TestCase(1)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Add_ElementAdd_ElementAddedSuccessfully(params int[] valuesToAdd)
        {
            Database database = new Database();

            database.Add(valuesToAdd);

            int[] currentFieldValues = GetDataField(database, valuesToAdd.Length);

            Assert.That(currentFieldValues, Is.EquivalentTo(valuesToAdd));
        }

        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 17, 17, 17)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 18, 19)]
        public void Add_AddMoreThan16Values_ExceptionTrown(params int[] valuesToAdd)
        {
            Database database = new Database();

            Assert.Catch<InvalidOperationException>(() => database.Add(valuesToAdd));
        }

        [TestCase(1, 2)]
        [TestCase(1, 2, 3)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void Remove_RemoveElement_ElementRemovedSuccefully(params int[] initialValues)
        {
            Database database = new Database(initialValues);

            database.Remove();

            initialValues = initialValues.SkipLast(1).ToArray();

            int currentIndex = (int)database.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.FieldType == typeof(int))
                .GetValue(database);

            int[] dbValues = GetDataField(database, currentIndex);

            Assert.That(dbValues, Is.EquivalentTo(initialValues));
        }

        [TestCase(1)]
        public void Remove_RemoveNotExistingElement_ExceptionTrown(params int[] initialValues)
        {
            Database database = new Database((initialValues));
            database.Remove();

            Assert.Catch<InvalidOperationException>(() => database.Remove());
        }

        [TestCase]
        [TestCase(1)]
        [TestCase(1, 2, 3, 4)]
        public void Fetch_FetchData_ReturnArrayWithData(params int[] initialValues)
        {
            Database database = new Database(initialValues);

            Assert.That(database.Fetch(), Is.EquivalentTo(initialValues));
        }

        public int[] GetDataField(Database database, int valuesCount)
        {
            FieldInfo fieldInfo = database.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.FieldType == typeof(int[]));

            int[] currentFieldValues = ((int[])fieldInfo.GetValue(database)).Take(valuesCount).ToArray();

            return currentFieldValues;
        }
    }
}
