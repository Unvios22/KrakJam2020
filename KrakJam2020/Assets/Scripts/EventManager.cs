using System;

public static class EventManager {
	public static event Action GameStartedEvent;
	public static event Action ConcreteStartedSplashingEvent;
	public static event Action ConcreteStoppedSplashingEvent;
	public static event Action ObstacleCollidedEvent;
	public static event Action CarCollidedEvent;
	public static event Action UnfilledHoleCollidedEvent;
	public static event Action PedestrianKilledEvent;
	public static event Action HoleFilledEvent;
	public static event Action CarStartedDriftingEvent;
	public static event Action CarStoppedDriftingEvent;
	public static event Action TruckColorChangedEvent;

	public static void OnGameStartedEvent() {
		GameStartedEvent?.Invoke();
	}

	public static void OnConcreteStartedSplashingEvent() {
		ConcreteStartedSplashingEvent?.Invoke();
	}

	public static void OnConcreteStoppedSplashingEvent() {
		ConcreteStoppedSplashingEvent?.Invoke();
	}

	public static void OnObstacleCollidedEvent() {
		ObstacleCollidedEvent?.Invoke();
	}

	public static void OnCarCollidedEvent() {
		CarCollidedEvent?.Invoke();
	}

	public static void OnUnfilledHoleCollidedEvent() {
		UnfilledHoleCollidedEvent?.Invoke();
	}

	public static void OnPedestrianKilledEvent() {
		PedestrianKilledEvent?.Invoke();
	}

	public static void OnHoleFilledEvent() {
		HoleFilledEvent?.Invoke();
	}

	public static void OnCarStartedDriftingEvent() {
		CarStartedDriftingEvent?.Invoke();
	}

	public static void OnCarStoppedDriftingEvent() {
		CarStoppedDriftingEvent?.Invoke();
	}

	public static void OnTruckColorChangedEvent() {
		TruckColorChangedEvent?.Invoke();
	}
}