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
            if (e is HitEvent hit) {
                onEvent(hit);
            } else if (e is DamageEvent dam) {
                onEvent(dam);
            } else if (e is MoveStartEvent movs) {
                onEvent(movs);
            } else if (e is MoveEndEvent move) {
                onEvent(move);
            } else if (e is JumpEvent jump) {
                onEvent(jump);
            } else if (e is ForceEvent force) {
                onEvent(force);
            } else if (e is WalkStartEvent walks) {
                onEvent(walks);
            } else if (e is WalkEndEvent walke) {
                onEvent(walke);
            } else if (e is GrappleEvent grap) {
                onEvent(grap);
            } else if (e is BlockEvent block) {
                onEvent(block);
            } else if (e is ParryEvent parry) {
                onEvent(parry);
            } else if (e is GuardSpentEvent grdsp) {
                onEvent(grdsp);
            } else if (e is MeterSpentEvent metsp) {
                onEvent(metsp);
            } else if (e is StunEvent stun) {
                onEvent(stun);
            } else if (e is DeathEvent death) {
                onEvent(death);
            } else if (e is MatchEndEvent end) {
                onEvent(end);
            } else if (e is UpdateEvent upd) {
                onEvent(upd);
            }

            throw new ArgumentException("Unknown event type");
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
