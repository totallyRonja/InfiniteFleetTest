using System;

public class ObservableValue<T> {
	private T _value;

	public T Value {
		get => _value;
		set {
			OnChange?.Invoke(value);
			_value = value;
		}
	}

	public Action<T> OnChange;

	public ObservableValue(T initial) {
		_value = initial;
	}
}
