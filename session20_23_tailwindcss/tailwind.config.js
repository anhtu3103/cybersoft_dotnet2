/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js}", "./node_modules/flowbite/**/*.js"], 
  theme: {
    extend: {
      container: {
        center: true,

      },
      backgroundColor:{
        mainColor: "#A2D2DF",
        secondColor: "#F6EFBD",
        bodyColor: '#151937',
      },
      textColor: {
        mainColor: '#A2D2DF',
        secondColor: "F6#FBD",
        profileColor: '#9334e9'
      },
      borderColor: {
        profileColor: '#9334e9'
      },
      backgroundImage: {
        'gradient-text': "linear-gradient(to left,#feac5e, #c779d0, #4bc0c8)"
      }
    },
  },
  plugins: [
    require('flowbite/plugin')
  ],
}

