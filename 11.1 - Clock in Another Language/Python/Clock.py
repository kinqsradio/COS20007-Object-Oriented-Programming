from Counter import Counter

class Clock:
    def __init__(self):
        self._seconds = Counter("seconds")
        self._minutes = Counter("minutes")
        self._hours = Counter("hours")
    
    def Tick(self):
        self._seconds.Increment()
        if self._seconds.Ticks > 59:
            self._minutes.Increment()
            self._seconds.Reset()
            if self._minutes.Ticks > 59:
                self._hours.Increment()
                self._minutes.Reset()
                if self._hours.Ticks > 23:
                    self.Reset()

    def Reset(self):
        self._seconds.Reset()
        self._minutes.Reset()
        self._hours.Reset()

    @property
    def Time(self):
        width = 2
        return str(self._hours.Ticks).zfill(width) + ":" + str(self._minutes.Ticks).zfill(width) + ":" + str(self._seconds.Ticks).zfill(width)
