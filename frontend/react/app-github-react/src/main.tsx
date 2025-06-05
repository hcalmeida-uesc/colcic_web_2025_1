// src/main.tsx
import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App.tsx';
import './style.css'; // Importando o CSS global
// Se não estiver usando CSS Modules e tiver um CSS global, importe aqui ou no App.tsx
// import './index.css'; // ou './style.css' se o nome for esse

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
);
