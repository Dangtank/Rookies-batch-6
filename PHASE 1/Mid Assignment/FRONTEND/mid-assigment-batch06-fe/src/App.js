import Register from './Pages/Register';
import Login from './Pages/Login';
import Home from './Pages/Home';
import { Routes, Route } from 'react-router-dom';
import Unauthorized from './Pages/Unauthorized';
import Layout from './Pages/Layout';
import RequireAuth from './Pages/RequiredAuth';
import Missing from './Pages/Missing';
import Lounge from './Pages/Lounge';
import Admin from './Pages/Admin';
import Editor from './Pages/Editor';
import LinkPage from './Pages/LinkPage';

const ROLES = {
  'User': "1",
  'Editor': "1",
  'Admin': "0"
}
function App() {

  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        {/* public routes */}
        <Route path="login" element={<Login />} />
        <Route path="register" element={<Register />} />
        <Route path="linkpage" element={<LinkPage />} />
        <Route path="unauthorized" element={<Unauthorized />} />

        {/* we want to protect these routes */}
        <Route element={<RequireAuth allowedRoles={[ROLES.User]} />}>
          <Route path="/" element={<Home/>} />
        </Route>

        <Route element={<RequireAuth allowedRoles={[ROLES.User]} />}>
          <Route path="editor" element={<Editor />} />
        </Route>


        <Route element={<RequireAuth allowedRoles={[ROLES.User]} />}>
          <Route path="admin" element={<Admin />} />
        </Route>

        <Route element={<RequireAuth allowedRoles={[ROLES.User, ROLES.Admin]} />}>
          <Route path="lounge" element={<Lounge />} />
        </Route>

        {/* catch all */}
        <Route path="*" element={<Missing />} />
      </Route>
    </Routes>
  );
}

export default App;