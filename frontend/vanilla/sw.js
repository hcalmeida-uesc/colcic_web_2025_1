const CACHE_NAME = 'minha-pwa-v1';
const urlsToCache = [
  '/frontend/vanilla/',
  '/frontend/vanilla/index.html',
  '/frontend/vanilla/style/index.css',
  '/frontend/vanilla/icon-192.png',
  '/frontend/vanilla/icon-512.png'
];

// Instalar Service Worker
self.addEventListener('install', function(event) {
  event.waitUntil(
    caches.open(CACHE_NAME)
      .then(function(cache) {
        return cache.addAll(urlsToCache);
      })
  );
});

// Buscar recursos do cache
self.addEventListener('fetch', function(event) {
  event.respondWith(
    caches.match(event.request)
      .then(function(response) {
        // Cache hit - retorna response
        if (response) {
          return response;
        }
        return fetch(event.request);
      }
    )
  );
});
