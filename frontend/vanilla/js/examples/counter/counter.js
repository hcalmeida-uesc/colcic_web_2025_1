/**
 * @file counter.js
 * @description Provides functions to increment and decrement a global counter variable.
 * @module counter
 */

/**
 * Global variable to hold the counter value.
 * @type {number}
 */
let valor = 0; 

/**
 * Increments the global variable `valor` by 1 and returns the new value.
 * @returns {number} The incremented value of `valor`.
 */
export function incrementar() {
  valor++;
  return valor;
}

/**
 * Decrements the global variable `valor` by 1 and returns the new value.
 * @returns {number} The decremented value of `valor`.
 */
export function decrementar() {
  valor--;
  return valor;
}
