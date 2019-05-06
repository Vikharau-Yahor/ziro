const CookieEventManager = Object.create(null, {
	initEvents: {
		value: function () {
			if (!this.cookieChangedEvent) {
				this.cookieChangedEvent = document.createEvent('Event');
				this.cookieChangedEvent.initEvent('CookieChangedEvent', true, true);
			}
		}
	},
	addCookieChangedHandler: {
		value: function (fn) {
			document.addEventListener('CookieChangedEvent', fn, false);
		}
	},
	invokeCookieChanged: {
		value: function () {
			document.dispatchEvent(this.cookieChangedEvent);
		}
	}
})

export default CookieEventManager