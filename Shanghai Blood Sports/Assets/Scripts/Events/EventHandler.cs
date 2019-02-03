using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events {
    public class EventHandler {
        public void onEvent<EVENT, ARGS>(EVENT e)
            where EVENT : Event<ARGS>
            where ARGS : EventArgs {
            switch (e) {
                case HitEvent ev:
                    onEvent(ev);
                    break;
                case DamageEvent ev:
                    onEvent(ev);
                    break;
                case MoveStartEvent ev:
                    onEvent(ev);
                    break;
                case MoveEndEvent ev:
                    onEvent(ev);
                    break;
                case JumpEvent ev:
                    onEvent(ev);
                    break;
                case ForceEvent ev:
                    onEvent(ev);
                    break;
                case WalkStartEvent ev:
                    onEvent(ev);
                    break;
                case WalkEndEvent ev:
                    onEvent(ev);
                    break;
                case GrappleEvent ev:
                    onEvent(ev);
                    break;
                case BlockEvent ev:
                    onEvent(ev);
                    break;
                case ParryEvent ev:
                    onEvent(ev);
                    break;
                case GuardSpentEvent ev:
                    onEvent(ev);
                    break;
                case MeterSpentEvent ev:
                    onEvent(ev);
                    break;
                case StunEvent ev:
                    onEvent(ev);
                    break;
                case DeathEvent ev:
                    onEvent(ev);
                    break;
                case MatchEndEvent ev:
                    onEvent(ev);
                    break;
                case UpdateEvent ev:
                    onEvent(ev);
                    break;
                default:
                    throw new ArgumentException("Unknown event type");
            }

        }

        public virtual void onEvent(HitEvent e) { }
        public virtual void onEvent(DamageEvent e) { }
        public virtual void onEvent(MoveStartEvent e) { }
        public virtual void onEvent(MoveEndEvent e) { }
        public virtual void onEvent(JumpEvent e) { }
        public virtual void onEvent(ForceEvent e) { }
        public virtual void onEvent(WalkStartEvent e) { }
        public virtual void onEvent(WalkEndEvent e) { }
        public virtual void onEvent(GrappleEvent e) { }
        public virtual void onEvent(BlockEvent e) { }
        public virtual void onEvent(ParryEvent e) { }
        public virtual void onEvent(GuardSpentEvent e) { }
        public virtual void onEvent(MeterSpentEvent e) { }
        public virtual void onEvent(StunEvent e) { }
        public virtual void onEvent(DeathEvent e) { }
        public virtual void onEvent(MatchEndEvent e) { }
        public virtual void onEvent(UpdateEvent e) { }
    }
}
