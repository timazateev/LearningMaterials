namespace LearningMaterials.Basics.Equality
{
	public class Person
	{
		public string? Name { get; set; }
		public int Age { get; set; }

		// Переопределяем Equals для сравнения объектов по значению
		public override bool Equals(object obj)
		{
			// Если сравниваем объект с самим собой
			if (ReferenceEquals(this, obj)) return true;

			// Если obj == null или не является объектом типа Person
			if (obj == null || obj.GetType() != this.GetType()) return false;

			// Приводим obj к типу Person и сравниваем значения полей
			Person other = (Person)obj;
			return this.Name == other.Name && this.Age == other.Age;
		}

		// Всегда переопределяем GetHashCode, если переопределяем Equals
		public override int GetHashCode()
		{
			// Используем хеш-коды полей Name и Age
			int hashName = Name?.GetHashCode() ?? 0;
			int hashAge = Age.GetHashCode();

			// Комбинируем хеш-коды
			return hashName ^ hashAge;
		}
	}

}
