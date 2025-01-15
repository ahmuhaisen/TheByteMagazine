module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  darkMode: false,
  theme: {
    extend: {
      fontFamily: {
        sans: ['"Work Sans"', 'sans-serif'],
      },
      colors: {
        'primary-dark': '#1d4f91',
        'primary-dark-2': '#0368b8',
        'primary-light': '#009cd5',
        'secondary': '#b8bb34',
        'tertiary': '#72d8f7',
      },
      borderWidth: {
        DEFAULT: '1px',
        '0': '0',
        '2': '2px',
        '4': '4px',
        '5': '5px',
        '8': '8px',
      }
    },
  },
  variants: {},
  plugins: [],
};
