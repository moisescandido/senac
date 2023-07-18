import { Registrar } from "./pages/Registrar";
import { Login } from "./pages/Login";
const AppRoutes = [
  {
    path: '/login',
    element: <Login />
  }, {
    path: '/registrar',
    element: <Registrar />
  }
];

export default AppRoutes;
